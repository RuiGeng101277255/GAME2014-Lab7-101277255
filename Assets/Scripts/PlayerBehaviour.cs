using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement")]
    public float HorizontalForce;
    public float VerticalForce;
    public bool isGrounded;
    public Transform groundOrigin;
    public float groundOriginRadius;
    public LayerMask groundLayerMask;

    private Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        checkIfGrounded();
    }

    private void Move()
    {
        if (isGrounded)
        {
            float delTime = Time.deltaTime;

            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            float jump = Input.GetAxisRaw("Jump");

            Vector2 worldTouch = new Vector2();

            foreach (var touch in Input.touches)
            {
                worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            }

            float HorizontalMoveForce = x * HorizontalForce * delTime;
            float JumpMoveForce = jump * VerticalForce * delTime;

            playerRB.AddForce(new Vector2(HorizontalMoveForce, JumpMoveForce));
            playerRB.velocity *= 0.98f;
        }
    }

    private void checkIfGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundOrigin.position, groundOriginRadius, Vector2.down, groundOriginRadius, groundLayerMask);

        isGrounded = (hit) ? true : false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundOrigin.position, groundOriginRadius);
    }
}
