using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBoss : MonoBehaviour
{
    public float health;
    public GameObject scytheWeapon;
    private GameObject player;
    [Range(.1f,1)]
    public float moveSpeed;
    
    public float range;
    private bool canSwing = true;
    public bool attacking;
    private Animator anim;
    private bool canTeleportOut = true;
    private bool canTeleport2;
    public bool canTeleport;
    public int teleportDelay;
    private float x;
    private Vector2 teleportLocation;
    public Transform location1;
    public Transform location2;
    public bool teleporting;
    public GameObject scythePrefab;
    public Transform spawnLoc;
    private bool hasAttacked;
    private bool inRange;
    public LayerMask playerLayer;
    public float rangeRadius;
    private Camera cam;
    public GameObject bossUI;

    public AudioSource teleOutSound;
    public AudioSource teleInSound;


    [Header("Delay")]
    public float swingDelay;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, rangeRadius, playerLayer) && !inRange)
        {
            inRange = true;
            cam.orthographicSize = Mathf.Lerp(6,7, .15f);

            bossUI.SetActive(true);
        }
        if(inRange)
        {
            var newPos = new Vector2(player.transform.position.x, transform.position.y);
            if (!attacking)
            {
                if(player.transform.position.x - transform.position.x < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                if (player.transform.position.x - transform.position.x > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                if(health >= 1250)
                {
                    transform.position = Vector2.Lerp(transform.position, newPos, moveSpeed * Time.deltaTime);
                }

            }

            if(health >= 1250)
            {
                if(Mathf.Abs(player.transform.position.x - transform.position.x) < 5 && canSwing)
                {
                ScytheSwing();
                }
            }
            else if(health < 1250)
            {
                TeleportOut();
                if(teleportDelay > 10 && !hasAttacked)
                {
                
                }
            }
        }

        


    }

    void ScytheSwing()
    {
        attacking = true;
        scytheWeapon.GetComponent<Animator>().SetTrigger("Swing");
        canSwing = false;
        StartCoroutine(SwingDelay());
        StartCoroutine(SwingTime());
    }

    void TeleportOut()
    {
        
        StartCoroutine(TeleportDelay3());
        if (canTeleportOut && canTeleport2)
        {
            teleporting = true;
            teleOutSound.Play();
            anim.SetTrigger("TeleportOut");
            canTeleportOut = false;
            StartCoroutine(TeleportDelay2());
            

        }
        if (canTeleport)
        {
            teleportDelay = Random.Range(7, 15);
            x = Random.Range(0, 100);
            if (x > 50)
            {
                teleportLocation = location1.position;
            }
            else if (x <= 50)
            {
                teleportLocation = location2.position;
            }
            transform.position = teleportLocation;
            
            canTeleport = false;
            StartCoroutine(TeleportDelay());
            StartCoroutine(TeleportSound());
            StartCoroutine(Teleporting());
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TeleportSound1()
    {
        teleOutSound.Play();
    }

    public void TeleportSound2()
    {
        teleInSound.Play();
    }

    IEnumerator TeleportDelay()
    {
        yield return new WaitForSeconds(teleportDelay);
        canTeleportOut = true;
        hasAttacked = false;
    }
    IEnumerator TeleportDelay2()
    {
        yield return new WaitForSeconds(.2f);
        canTeleport = true;
    }
    IEnumerator TeleportDelay3()
    {
        yield return new WaitForSeconds(.2f);
        canTeleport2 = true;
    }
    IEnumerator Teleporting()
    {
        yield return new WaitForSeconds(2.2f);
        teleporting = false;
        
    }
    IEnumerator TeleportSound()
    {
        yield return new WaitForSeconds(1.4f);
        
        teleInSound.Play();
    }
    IEnumerator SwingTime()
    {
        yield return new WaitForSeconds(1.40f);
        attacking = false;
    }
    IEnumerator SwingDelay()
    {
        yield return new WaitForSeconds(swingDelay);
        canSwing = true;
    }
}
