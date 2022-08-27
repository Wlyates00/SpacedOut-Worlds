using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup2 : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject, .1f);
            
        }
    }
}
