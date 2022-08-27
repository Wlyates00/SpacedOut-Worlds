using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootHand : MonoBehaviour
{
    private GameObject player;
    public float range;
    public float startDelay = 2f;
    public float shotDelay = 5f;
    public GameObject shotPrefab;
    public Transform firePoint;
    public bool inRange;
    public bool canShoot = true;
    public GameObject boss;
    
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDir = transform.position - player.transform.position;
        playerDir = new Vector2(playerDir.x, playerDir.y - 1.75f);
        float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        ShootAttack();
        
    }

    void ShootAttack()
    {
        if (!inRange)
        {
            canShoot = true;
        }
        if (Physics2D.OverlapCircle(transform.position, range, playerLayer))
        {
            inRange = true;
        }
        if(inRange && canShoot)
        {
            if (!boss.GetComponent<SecondBoss>().teleporting)
            {
                canShoot = false;
                Instantiate(shotPrefab, firePoint.position, Quaternion.identity);
                StartCoroutine(ShootDelay());
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(2.75f);
        canShoot = true;
    }
}
