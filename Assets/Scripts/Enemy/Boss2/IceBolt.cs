using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBolt : MonoBehaviour
{
    private GameObject player;
    public float shotSpeed;
    public float damage;
    public bool notForced = true;
    private Rigidbody2D rb;
    private Vector2 targetPos;
    public AudioSource iceSound;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerDir = transform.position - player.transform.position;
        playerDir = new Vector2(playerDir.x, playerDir.y - 2f);
        float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector2 playerPos = player.transform.position;
        Vector2 bulletPos = transform.position;
        playerPos.y = playerPos.y + 1.75f;
        float targetX = playerPos.x - bulletPos.x;
        float targetY = playerPos.y - bulletPos.y;
        targetPos = new Vector2(targetX, targetY);
        

        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        Vector2 playerDir = transform.position - player.transform.position;
        if (playerDir.x - transform.position.x > 5)
        {
            shotSpeed = 1f;
        }
        else if (playerDir.x - transform.position.x < 5)
        {
            shotSpeed = 2f;
        }
        if (notForced)
        {
            GetComponent<Rigidbody2D>().AddForce(targetPos * shotSpeed, ForceMode2D.Impulse);
            notForced = false;
        }



    }

    public void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.tag == "Player")
        {
            player.GetComponent<Health>().PlayerDamage(damage);
            Destroy(gameObject, .07f);
            iceSound.Play();
        }
        
    }
}
