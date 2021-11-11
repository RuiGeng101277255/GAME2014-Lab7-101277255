using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Platform Movement")]
    public MovingDirection dir;

    [Range(0.1f, 10.0f)]
    public float speed;

    [Range(1.0f, 25.0f)]
    public float dist;

    public bool isLooping;

    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    private void movePlatform()
    {
        switch (dir)
        {
            case MovingDirection.HORIZONTAL:
                transform.position = new Vector2(startPos.x + Mathf.PingPong(Time.time * speed, dist), transform.position.y);
                break;
            case MovingDirection.VERTICAL:
                transform.position = new Vector2(transform.position.x, startPos.y + Mathf.PingPong(Time.time * speed, dist));
                break;
            case MovingDirection.DIAGONAL_UP:
                transform.position = new Vector2(startPos.x + Mathf.PingPong(Time.time * speed, dist), startPos.y + Mathf.PingPong(Time.time * speed, dist));
                break;
            case MovingDirection.DIAGONAL_DOWN:
                transform.position = new Vector2(startPos.x + Mathf.PingPong(Time.time * speed, dist), startPos.y - Mathf.PingPong(Time.time * speed, dist));
                break;
        }
    }
}
