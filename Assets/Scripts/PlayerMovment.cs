using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    //private Animator anim;
    private Rigidbody2D rb;
    public float velocity;
    private Vector2 horizontal;
    public float speed = 5f;
    private bool isFacingRight;
    //private bool isIdle;
    private bool shiftDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Input.GetAxisRaw("Horizontal");
        Move();
        IdleCheck();
        Flip();
       // anim.SetFloat("Velocity", Mathf.Abs(velocity));
        //anim.SetBool("isIdle", isIdle);
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
        }
        else
        {
            speed = 5f;
        }
        Vector2 horizontal = new Vector2(velocity, rb.velocity.y);
        //rb.AddForce(horizontal * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        transform.Translate(velocity * horizontal * speed * Time.deltaTime);
        
    }

    void IdleCheck()
    {
        if (velocity == 0)
        {
            //isIdle = true;
        }
        else
        {
            //isIdle = false;
        }
    }

    protected void Flip()
    {
        isFacingRight = !isFacingRight;

        if (velocity < 0)
        {
            isFacingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if(velocity > 0)
        {
            isFacingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        
    }
}
