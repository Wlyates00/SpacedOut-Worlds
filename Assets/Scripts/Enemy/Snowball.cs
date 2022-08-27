using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float damage;
    public float speed;
    public LayerMask playerLayer;
    private GameObject player;
    public bool inRange;
    public float radius;
    public GameObject snowFX1;
    public GameObject snowFX2;
    public Transform circleLocation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 rollDir = player.transform.position - transform.position;
        inRange = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (player != null && inRange)
        {
            rb.AddForce(rollDir * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        if(rb.velocity.x > 0)
        {
            snowFX1.transform.rotation = Quaternion.Euler(0, 0, 180);
            snowFX2.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (rb.velocity.x < 0)
        {
            snowFX1.transform.rotation = Quaternion.Euler(0, 0, 0);
            snowFX2.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<Health>().PlayerDamage(damage);
            GameObject effectOne = Instantiate(snowFX1, transform.position, Quaternion.identity);
            GameObject effectTwo = Instantiate(snowFX2, transform.position, Quaternion.identity);
            Destroy(effectOne, 1f);
            Destroy(effectTwo, 1f);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Destroyable")
        {
            GameObject effectOne = Instantiate(snowFX1, transform.position, Quaternion.identity);
            GameObject effectTwo = Instantiate(snowFX2, transform.position, Quaternion.identity);
            Destroy(effectOne, 1f);
            Destroy(effectTwo, 1f);
            Destroy(gameObject);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
