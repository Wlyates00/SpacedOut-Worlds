using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    //patrolling variables
    public float speed;
    private float moveDir = 1;
    private bool facingRight = true;
    public Transform groundCheckPoint;
    public Transform wallCheckPoint;
    public float radius;
    public LayerMask groundLayer;
    public LayerMask destroyableLayer;
    private bool checkWall;
    private bool checkGround;
    
    private Rigidbody2D rb;
    public int health;
    public float damage = 1.5f;

    //attack
    public float jumpPower;
    [SerializeField] private Transform player;
    public Transform groundCheck;
    public Vector2 boxSize;
    private bool isGrounded;
    //range
    public float range = 8;
    public Transform rangeCircle;
    public LayerMask playerLayer;
    private bool inRange = false;
    private bool engaged = false;
    //public GameObject[] destroyable;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //destroyable = GameObject.FindGameObjectsWithTag("Destroyable");
    }

    private void Update()
    {
        InRange();
        checkGround = Physics2D.OverlapCircle(groundCheckPoint.position, radius, groundLayer) || Physics2D.OverlapCircle(groundCheckPoint.position, radius, destroyableLayer);
        checkWall = Physics2D.OverlapCircle(wallCheckPoint.position, radius, groundLayer) || Physics2D.OverlapCircle(wallCheckPoint.position, radius, destroyableLayer);
        //isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, groundLayer);
        //Patrolling();
        if (engaged)
        {
            JumpAttack();
        }
        else if (!engaged)
        {
            Patrolling();
        }
        
        float checkingGround = rb.velocity.y;
        if (checkingGround == 0)
        {
            isGrounded = true;
        }
        else if(checkingGround > 0)
        {
            isGrounded = false;
        }
        
    }

    void InRange()
    {
        inRange = Physics2D.OverlapCircle(rangeCircle.position, range, playerLayer);
        if (inRange)
        {
            engaged = true;
        }
    }
    void Patrolling()
    {
        if (!checkGround || checkWall)
        {
            if (facingRight)
            {
                EnemyFlip();
            }
                
            else if (!facingRight)
            {
                EnemyFlip();
            }
                
        }
        rb.velocity = new Vector2(speed * moveDir, rb.velocity.y);
    }

    void JumpAttack()
    {
        float distFromPlayer = player.position.x - transform.position.x;
        FlipToPlayer();
        if (isGrounded)
        {
            rb.AddForce(new Vector2(distFromPlayer, jumpPower), ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundCheck.position, boxSize);
        Gizmos.DrawWireSphere(rangeCircle.position, range);
    }
    void EnemyFlip()
    {
        moveDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    void FlipToPlayer()
    {
        float distFromPlayer = player.position.x - transform.position.x;
        if(distFromPlayer < 0 && facingRight)
        {
            EnemyFlip();
        }
        else if(distFromPlayer > 0 && !facingRight)
        {
            EnemyFlip();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<Health>().PlayerDamage(damage);
        }
    }
}
