using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    public int health = 30;
    public float damage = 1;
    public GameObject player;
    public AudioSource wormUpSound;
    public AudioSource deathSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wormUpSound.Play();
        wormUpSound.volume = 0;
    }
    private void Update()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 9 && Mathf.Abs(transform.position.y - player.transform.position.y) < 9)
        {
            wormUpSound.volume = .065f;
        }
        /*else if (Mathf.Abs(transform.position.x - player.transform.position.x) < 11 && Mathf.Abs(transform.position.y - player.transform.position.y) < 9)
        {
            wormUpSound.volume = .75f;
        }*/
        else if (Mathf.Abs(transform.position.x - player.transform.position.x) > 9)
        {
            wormUpSound.volume = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        { 
            if(player != null)
            {
                player.GetComponent<Health>().PlayerDamage(damage);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player != null)
            {
                player.GetComponent<Health>().PlayerDamage(damage);
            }

        }
    }

    public void TakeDamage(int damage)
    {
        if(health > 0)
        {
            health -= damage;
            if (health <= 0)
            {
            
                deathSound.Play();
                Destroy(gameObject, .2f);
            }
        }
        
    }

    public void PlayWormSound()
    {
        wormUpSound.Play();
    }
}
