using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : MonoBehaviour
{
    public float BossSpeed;
    public float hitDamage = 3;
    public GameObject player;
    public Transform laserPosition;
    public GameObject LaserPrefab;
    Rigidbody2D rb;
    public GameObject spikeFX;
   // public Transform gate;
   // public bool gateGrounded;
    private bool canShootLaser = true;
    public float laserDelay;
    public float health;

    public GameObject bossHealth;
    public GameObject beePrefab;
    public Transform beeLocationOne;
    public float beeDelay;
    private bool canShootBees = true;

    public float rushSpeed;
    private bool canRush = true;
    public float rushDelay;
    private bool inPosition;
    public Transform firePoint;
    public GameObject bossShotPrefab;
    //public Vector2 shotDir;

    public float chaseTime;
    private float ogY;
    private bool firstgo = true;
    public bool facingLeft;

    public Transform firepointLeft;
    public Transform firepointRight;
    private bool shot;

    //public Transform cam;
    public GameObject spikePrefab1;
    public GameObject spikePrefab2;
    public GameObject spikePrefab3;
    public GameObject spikePrefab4;

    public bool notSpiked = true;
    public Transform spotOne;
    public Transform spotTwo;
    public Transform spotThree;
    public Transform spotFour;

    public Transform box;
    public Vector2 boxSize;
    public bool hitdetected;
    public LayerMask playerLayer;
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ogY = transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        float distBtw = Mathf.Abs(player.transform.position.x - transform.position.x);
        //gateGrounded = gate.GetComponent<Gate>().groundedGate;
        if (trigger.GetComponent<PlayerTrigger>().attackPlayer && player != null)
        {
            bossHealth.SetActive(true);
            if(facingLeft  && player.transform.position.x > transform.position.x)
            {
                facingLeft = false;
            }
            else if (!facingLeft && player.transform.position.x < transform.position.x)
            {
                facingLeft = true;
            }
            if (distBtw < 30 && health > 500)
            {
                BossLaser();
                if (canShootBees)
                {
                    SpawnBees();
                }
               
            }
            else if (health <= 500)
            {
                if (canRush)
                {
                    BossRush();
                }
                else if (!canRush)
                {
                    BossShots();
                }
                
                
            }
        }
        
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(box.position, boxSize);
    }

    void BossLaser()
    {
        Vector2 targPos = new Vector2(player.transform.position.x, transform.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, targPos, BossSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        if (canShootLaser)
        {
            Instantiate(LaserPrefab, laserPosition.position, Quaternion.identity, transform);
            canShootLaser = false;
            StartCoroutine(LaserDelay());
            
        }
        
    }
    void SpawnBees()
    {
        canShootBees = false;
        StartCoroutine(BeeDelay());
        Instantiate(beePrefab, beeLocationOne.position, Quaternion.identity);

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void BossRush()
    {
        inPosition = false;
        canRush = true;
        if (firstgo)
        {
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), rushSpeed * Time.fixedDeltaTime);
            if(transform.position.y <= player.transform.position.y + 3.5)
            {
                if (!shot && facingLeft)
                {
                    Instantiate(bossShotPrefab, firepointLeft.position, Quaternion.identity);
                    shot = true;
                    StartCoroutine(ShotDelay());
                }
                else if (!shot && !facingLeft)
                {
                    Instantiate(bossShotPrefab, firepointRight.position, Quaternion.identity);
                    shot = true;
                    StartCoroutine(ShotDelay());
                }
            }
        }
        else if (!firstgo)
        {
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), rushSpeed * 2.4f * Time.fixedDeltaTime);
            if (transform.position.y <= player.transform.position.y+ 3.5)
            {
                if (!shot && facingLeft)
                {
                    Instantiate(bossShotPrefab, firepointLeft.position, Quaternion.identity);
                    shot = true;
                    StartCoroutine(ShotDelay());
                }
                else if (!shot && !facingLeft)
                {
                    Instantiate(bossShotPrefab, firepointRight.position, Quaternion.identity);
                    shot = true;
                    StartCoroutine(ShotDelay());
                }
            }
        }

        StartCoroutine(RushDelay());
        StartCoroutine(ChaseTime());
        
    }

    void BossShots()
    {
        if (!inPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 6, transform.position.x), rushSpeed);
            if(transform.position.y > ogY)
            {
                inPosition = true;
            }
        }
        else if (inPosition)
        {
            
            if (notSpiked)
            {
                notSpiked = false;
                //Instantiate(spikeFX, spotOne.position, Quaternion.identity);
                //Instantiate(spikePrefab1, spotOne.position, Quaternion.identity);
                /*Instantiate(spikeFX, spotTwo.position, Quaternion.identity);
                Instantiate(spikePrefab2, spotTwo.position, Quaternion.identity);
                Instantiate(spikeFX, spotThree.position, Quaternion.identity);
                Instantiate(spikePrefab3, spotThree.position, Quaternion.identity);
                Instantiate(spikeFX, spotFour.position, Quaternion.identity);
                Instantiate(spikePrefab4, spotFour.position, Quaternion.identity);*/
                spikePrefab1.SetActive(true);
                spikePrefab2.SetActive(true);
                spikePrefab3.SetActive(true);
                spikePrefab4.SetActive(true);
                StartCoroutine(SpikeDelay());
            }

            //Next attack
        }
    }

    
    IEnumerator BeeDelay()
    {
        yield return new WaitForSeconds(beeDelay);
        canShootBees = true;
    }

    IEnumerator LaserDelay()
    {
        yield return new WaitForSeconds(laserDelay);
        canShootLaser = true;
    }

    IEnumerator RushDelay()
    {
        yield return new WaitForSeconds(rushDelay);
        canRush = false;
        firstgo = false;
    }

    IEnumerator ChaseTime()
    {
        
        yield return new WaitForSeconds(chaseTime);
        canRush = true;
    }

    IEnumerator ShotDelay()
    {

        yield return new WaitForSeconds(rushDelay);
        shot = false;
    }

    IEnumerator SpikeDelay()
    {

        yield return new WaitForSeconds(rushDelay + 5f);
        notSpiked = true;
    }
}
