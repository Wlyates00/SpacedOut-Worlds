using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : MonoBehaviour
{
    private GameObject player;
    public float damage;
    public float speed;
    public float range;
    private Rigidbody2D rb;
    private bool inRange;
    public float delay = 2.5f;
    public LayerMask playerLayer;
    private bool delete;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var playerDir = player.transform.position - transform.position;
        inRange = Physics2D.OverlapCircle(transform.position, range, playerLayer);
        if(inRange && player != null)
        {
            rb.AddForce(playerDir * speed, ForceMode2D.Impulse);
            StartCoroutine("DestroyDelay");

        }
        if (delete == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<Health>().PlayerDamage(damage);
            Destroy(gameObject, 1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(delay);
        delete = true;
    }
}
