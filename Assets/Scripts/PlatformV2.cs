using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformV2 : MonoBehaviour
{
    public float speed;
    public Vector2 boxsize;
    public bool onPlatform;
    public LayerMask playerLayer;
    public Transform boxPoint;
    //Animator anim;
    public Transform endPoint1;
    public Transform endPoint2;
    Rigidbody2D rb;
    public Vector2 endPosOne;
    private bool goingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        endPosOne = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.y <= endPosOne.y)
        {
            rb.velocity = new Vector2(0, speed);
            goingUp = true;
        }
        else if (rb.position.y >= endPoint2.position.y)
        {
            rb.velocity = -rb.velocity;
            goingUp = false;
            //rb.velocity = new Vector2(rb.position.x, -speed * Time.deltaTime);
        }
        if (goingUp)
        {
            rb.velocity = new Vector2(0, speed);
        }
        else if (!goingUp)
        {
            rb.velocity = new Vector2(0, -speed);
        }
    }

}
