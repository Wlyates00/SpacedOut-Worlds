using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHorizontalProjectile : MonoBehaviour
{
    public float damage;
    public float bulletForce;
    private GameObject boss;
    private GameObject player;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(boss != null)
        {
            float projDir = player.transform.position.x - boss.transform.position.x;
            if (projDir < 0 && boss.GetComponent<FirstBoss>().facingLeft)
            {
                rb.AddForce(new Vector2(-bulletForce, -.3f), ForceMode2D.Impulse);
            }
        
            if (projDir > 0 && !boss.GetComponent<FirstBoss>().facingLeft)
            {
                rb.AddForce(new Vector2(bulletForce, -.3f), ForceMode2D.Impulse);
            }
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<Health>().PlayerDamage(damage);
        }
    }
}
