using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public int health;
    public float speed;
    public float rangeRadius;
    public LayerMask playerLayer;
    public GameObject player;
    public Transform enemyRange;
    public bool inRange;

    //shooting
    private Vector2 playerPos;
    public GameObject shotPrefab;
    public Transform firePoint;
    public float shotDelay;
    private bool canShoot = true;

    private bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FlipEnemy();
        EnemyRange();
        if (inRange)
        {
            Vector3 playerDir = player.transform.position - transform.position + new Vector3(0, 2, 0);
            transform.Translate(playerDir * speed * Time.deltaTime);
            EnemyShooting();
        }

        playerPos = player.transform.position;
    }
    void FlipEnemy()
    {
        if(transform.position.x != player.transform.position.x)
        {
            if (facingLeft && transform.position.x < player.transform.position.x)
            {
                transform.Rotate(0, 0, 0);
                facingLeft = false;
            }
            else if (!facingLeft && transform.position.x > player.transform.position.x)
            {
                transform.Rotate(0, 180, 0);
                facingLeft = true;
            }
        }

    }
    void EnemyRange()
    {
        inRange = Physics2D.OverlapCircle(enemyRange.position, rangeRadius, playerLayer);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyRange.position, rangeRadius);
    }
    public void EnemyShooting()
    {
        if (canShoot)
        {
            GameObject enemyBullet = Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
            Destroy(enemyBullet, 6f);
            canShoot = false;
            StartCoroutine(ShootDelay());
        }

    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shotDelay);
        canShoot = true;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
