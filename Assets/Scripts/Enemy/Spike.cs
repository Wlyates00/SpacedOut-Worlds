using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float damage;

    private GameObject boss;
    private void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
    }
    private void Update()
    {
        if(boss != null)
        {
            if (!boss.GetComponent<FirstBoss>().notSpiked)
            {
                Destroy(gameObject, 8f);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().PlayerDamage(damage);
        }
    }
}
