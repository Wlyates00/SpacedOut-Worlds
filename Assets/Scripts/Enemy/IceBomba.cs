using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBomba : MonoBehaviour
{
    public float damage;
    public int health;
    public float runSpeed;
    public float jumpPower;
    public float blastForce;
    public float rangeRadius;
    public LayerMask playerLayer;
    private bool isRunning = true;
    private bool hasJumped;
    private bool facingLeft;
    private bool inRange;
    private Rigidbody2D rb;
    private GameObject player;
    public AudioSource fuseSound;

    public GameObject explosionFX1;
    public GameObject explosionFX2;
    public GameObject explosionFX3;

    private GameObject spawners;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        spawners = GameObject.FindGameObjectWithTag("Spawners");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float playerDir = player.transform.position.x - transform.position.x;
        if(playerDir < 0)
        {
            playerDir = -1;
            facingLeft = true;

        }
        else if (playerDir > 0)
        {
            playerDir = 1;
            facingLeft = false;
        }
        if(facingLeft == false)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (facingLeft == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        inRange = Physics2D.OverlapCircle(transform.position, rangeRadius, playerLayer);
        if (inRange)
        {
            
        }
        if (inRange && isRunning)
        {
            fuseSound.Play();
            rb.AddForce(new Vector2(playerDir * runSpeed, rb.position.y), ForceMode2D.Impulse);
            isRunning = false;
        }

        if(Mathf.Abs(player.transform.position.x - transform.position.x) < 4 && !hasJumped)
        {

            rb.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
            hasJumped = true;
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            GameObject effect1 = Instantiate(explosionFX1, new Vector3(transform.position.x, transform.position.y, -9f), Quaternion.identity);
            Destroy(effect1, .3f);
            GameObject effect2 = Instantiate(explosionFX2, new Vector3(transform.position.x, transform.position.y, -9f), Quaternion.identity);
            Destroy(effect2, .3f);
            GameObject effect3 = Instantiate(explosionFX3, new Vector3(transform.position.x, transform.position.y, -9f), Quaternion.identity);
            Destroy(effect3, .3f);
            if(spawners != null)
            {
                spawners.GetComponent<EndlessScore>().enemiesKilled += 1;
            }
            
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<Health>().PlayerDamage(damage);
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * blastForce, ForceMode2D.Impulse);
            GameObject effect1 = Instantiate(explosionFX1, new Vector3(transform.position.x, transform.position.y, -9f), Quaternion.identity);
            Destroy(effect1, .3f);
            GameObject effect2 = Instantiate(explosionFX2, new Vector3(transform.position.x, transform.position.y, -9f), Quaternion.identity);
            Destroy(effect2, .3f);
            GameObject effect3 = Instantiate(explosionFX3, new Vector3(transform.position.x, transform.position.y, -9f), Quaternion.identity);
            Destroy(effect3, .3f);
            Destroy(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }
}
