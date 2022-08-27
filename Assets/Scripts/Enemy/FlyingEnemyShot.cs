using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyShot : MonoBehaviour
{
    private GameObject player;
    public float shotSpeed;
    public float damage;
    private Rigidbody2D rb;
    private Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.transform.position;
        Vector2 bulletPos = transform.position;
        playerPos.y = playerPos.y + 2;
        float targetX = playerPos.x - bulletPos.x;
        float targetY = playerPos.y - bulletPos.y;
        targetPos = new Vector2(targetX, targetY);
        
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(targetPos * shotSpeed, ForceMode2D.Impulse);

    }

    public void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.tag == "Player")
        {
            player.GetComponent<Health>().PlayerDamage(damage);
        }
    }
}
