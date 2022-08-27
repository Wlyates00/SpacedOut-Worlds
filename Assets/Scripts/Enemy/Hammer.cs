using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Hammer : MonoBehaviour
{
    public float damage = 1;
    private bool playerCheck;
    private Rigidbody2D rb;
    public float speed;
    private Vector3 startPos;
    public float downDistance;
    private Vector3 zeroVel;
    private Health health;
    public Transform player;
    public Transform hammer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        zeroVel = Vector3.zero;
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerPosX = Mathf.Round(player.position.x);
        float hammerPosX = Mathf.Round(hammer.position.x);
        if (playerPosX == hammerPosX)
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            Vector3 targetPos = new Vector3(startPos.x, startPos.y + downDistance, startPos.z);
            rb.AddForce(-rb.transform.up * speed);
            
        }
    }

    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().PlayerDamage(damage);
        }
        else
        {

        }
    }
}
