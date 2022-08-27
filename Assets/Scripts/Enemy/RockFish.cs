using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RockFish : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public int health;
    public float damage;
    public float attackDelay;
    private GameObject player;
    public bool inRange;
    public LayerMask playerLayer;
    public float range;
    public Transform rangePoint;
    private bool canAttack = true;

    private GameObject spawners;
    public bool canChange;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        spawners = GameObject.FindGameObjectWithTag("Spawners");
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Physics2D.OverlapCircle(rangePoint.position, range, playerLayer))
        {
            inRange = true;
        }
        if (inRange == true)
        {
            Vector2 playerDir = transform.position - player.transform.position;
            playerDir = new Vector2(playerDir.x, playerDir.y - 2f);
            float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.Translate(playerDir * speed * Time.deltaTime);
            if (canAttack)
            {
                rb.AddForce(-playerDir * speed * Time.deltaTime, ForceMode2D.Impulse);

                StartCoroutine(Falsify());
                StartCoroutine(AttackDelay());
            }
            else if (!canAttack)
            {
                rb.velocity = rb.velocity * .95f;
            }

        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rangePoint.position, range);
    }

    IEnumerator Falsify()
    {
        yield return new WaitForSeconds(1);
        canAttack = false;
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.GetComponent<Health>().PlayerDamage(damage);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            canChange = true;
            if (spawners != null)
            {
                spawners.GetComponent<EndlessScore>().enemiesKilled += 1;
            }
            Destroy(gameObject);
        }
    }

   
}
