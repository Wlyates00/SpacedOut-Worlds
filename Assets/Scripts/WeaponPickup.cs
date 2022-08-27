using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponPickup : MonoBehaviour
{
    public bool hasWeapon1;
    public GameObject uziPic;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject, .1f);
            hasWeapon1 = true;
            uziPic.SetActive(true);
        }
    }
}
