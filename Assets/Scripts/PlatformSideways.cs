using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSideways : MonoBehaviour
{
    public float speed;
    public Transform endPoint;
    private Rigidbody2D rb;
    private Vector2 endPos;
    private bool goingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        endPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.x <= endPos.x)
        {
            rb.velocity = new Vector2(speed, 0);
            goingRight = true;
        }
        else if (rb.position.x >= endPoint.position.x)
        {
            rb.velocity = new Vector2(-speed, 0);
            goingRight = false;
        }
        if (goingRight)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else if (!goingRight)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
    }
}
