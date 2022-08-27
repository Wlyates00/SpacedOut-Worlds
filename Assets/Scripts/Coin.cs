using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject player;
    public AudioSource coinHitSound;
    public bool coinHit;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && player != null)
        {
            coinHit = true;
            player.GetComponent<CollectCoins>().CoinsTotalHit();
            
            Destroy(gameObject);
            coinHit = false;
        }
    }
}
