using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitFX;
    public GameObject player;
    public int damage = 10;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if(player != null)
        {
            if(player.GetComponent<PlayerActionScrpit>().currentWeaponIndex == 0)
            {
                damage = 10;
            }
            else if(player.GetComponent<PlayerActionScrpit>().currentWeaponIndex == 1)
            {
                damage = 4;
            }
            else if(player.GetComponent<PlayerActionScrpit>().currentWeaponIndex == 2)
            {
                damage = 18;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(hitFX, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
        Destroyable destroy = collision.GetComponent<Destroyable>();
        if(destroy != null)
        {
            destroy.TakeDamage(damage);
        }
        JumpingEnemy enemy = collision.GetComponent<JumpingEnemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        DecoyDestroyable decoy = collision.GetComponent<DecoyDestroyable>();
        if(decoy != null)
        {
            decoy.TakeDamage(damage);
        }
        FlyingEnemy flyingEnemy = collision.GetComponent<FlyingEnemy>();
        if(flyingEnemy != null)
        {
            flyingEnemy.TakeDamage(damage);
        }
        FirstBoss boss = collision.GetComponent<FirstBoss>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
        Worm worm = collision.GetComponent<Worm>();
        if (worm != null)
        {
            worm.TakeDamage(damage);
        }
        RockFish rockFish = collision.GetComponent<RockFish>();
        if(rockFish != null)
        {
            rockFish.TakeDamage(damage);
        }
        IceBomba iceBomba = collision.GetComponent<IceBomba>();
        if(iceBomba != null)
        {
            iceBomba.TakeDamage(damage);
        }
        SecondBoss boss2 = collision.GetComponent<SecondBoss>();
        if(boss2 != null)
        {
            boss2.TakeDamage(damage);
        }
    }



}
