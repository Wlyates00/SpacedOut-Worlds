using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerGrounding : MonoBehaviour
{
    public Transform groundCheck;
    public bool isGrounded;

    public Transform cam;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            Destroy(gameObject, 0.1f);
            isGrounded = true;
            
        }
        else if (collision.tag == "Player")
        {
            Destroy(gameObject, 0.1f);
            isGrounded = true;
        }
        else if (collision.tag == "Enemy")
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
