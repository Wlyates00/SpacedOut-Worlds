using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform firePointMain;
    //for shotty

    public Transform firePointOne;
    public Transform firePointTwo;
    //

    public GameObject bulletPrefab;
    public float bulletForce;
    public GameObject player;
    public AudioSource shotSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PlayerShot()
    {
        if (player.GetComponent<PlayerActionScrpit>().currentWeaponIndex == 0 || player.GetComponent<PlayerActionScrpit>().currentWeaponIndex == 1)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePointMain.position, firePointMain.rotation);
            shotSound.Play();
            rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePointMain.right * bulletForce, ForceMode2D.Impulse);
        }
        if (player.GetComponent<PlayerActionScrpit>().currentWeaponIndex == 2)
        {
            Quaternion bulletOneRotation = Quaternion.Euler(firePointMain.rotation.x, firePointMain.rotation.y, firePointMain.rotation.z + 10f);
            Quaternion bulletTwoRotation = Quaternion.Euler(firePointMain.rotation.x, firePointMain.rotation.y, firePointMain.rotation.z - 10f);
            GameObject bullet = Instantiate(bulletPrefab, firePointMain.position, firePointMain.rotation);
            GameObject bullet1 = Instantiate(bulletPrefab, firePointOne.position, firePointOne.rotation);
            GameObject bullet2 = Instantiate(bulletPrefab, firePointTwo.position, firePointTwo.rotation);
            shotSound.Play();

            rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.right * bulletForce, ForceMode2D.Impulse);
            rb = bullet1.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet1.transform.right * bulletForce, ForceMode2D.Impulse);
            rb = bullet2.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet2.transform.right * bulletForce, ForceMode2D.Impulse);
        }
    }
}
