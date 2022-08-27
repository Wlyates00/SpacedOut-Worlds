using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectCoins : MonoBehaviour
{
    public int coinsCollected;
    public float healthAddAmt;
    public int coinsTotal;
    public int coinsAmt;
    private int coinsStart = 0;
    public GameObject player;
    public GameObject coin;
    public TextMeshProUGUI coinText;
    

    private void Start()
    {
        coinsCollected = coinsStart;
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void Update()
    {
        if(coin != null)
        {
            if (coin.GetComponent<Coin>().coinHit)
            {
                CoinsTotalHit();
            }
        }
        

    }

    public void CoinsTotalHit()
    {
        coinsCollected += coinsAmt;
        if (coinsCollected >= coinsTotal)
        {
            player.GetComponent<Health>().AddHealth(healthAddAmt);
            coinsCollected = coinsStart;
            
        }
        coinText.text = "X" + coinsCollected as string;
    }
}
