using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public int health = 30;
    public GameObject explosionFX1;
    public GameObject explosionFX2;
    public GameObject explosionFX3;

    public GameObject coinPrefab;

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            float x = Random.Range(0, 15);
            
            
            GameObject effect1 = Instantiate(explosionFX1, new Vector3(transform.position.x,transform.position.y, -9f), Quaternion.identity);
            Destroy(effect1, .3f);
            GameObject effect2 = Instantiate(explosionFX2, new Vector3(transform.position.x, transform.position.y, -9f), Quaternion.identity);
            Destroy(effect2, .3f);
            GameObject effect3 = Instantiate(explosionFX3, new Vector3(transform.position.x, transform.position.y, -9f), Quaternion.identity);
            Destroy(effect3, .3f);
            Destroy(gameObject);
            if (x > 5)
            {
                Instantiate(coinPrefab, pos1.position, Quaternion.identity);
            }
            else if (x < 12)
            {
                Instantiate(coinPrefab, pos1.position, Quaternion.identity);
                Instantiate(coinPrefab, pos2.position, Quaternion.identity);
            }
            else if (x == 10)
            {
                Instantiate(coinPrefab, pos1.position, Quaternion.identity);
                Instantiate(coinPrefab, pos2.position, Quaternion.identity);
                Instantiate(coinPrefab, pos3.position, Quaternion.identity);
            }
        }
    }
}
