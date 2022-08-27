using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    private Health health;
    private GameObject player;
    public float damage;
    private void Start()
    {
        health = GetComponent<Health>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().PlayerDamage(damage);
            
        }
        
    }
    private void Update()
    {
        Destroy(gameObject, 1);
    }


}
