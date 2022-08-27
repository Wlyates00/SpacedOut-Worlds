using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyDestroyable : MonoBehaviour
{
    public int health = 40;
    public GameObject enemyPrefab;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
