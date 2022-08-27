using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingPlayerCheck : MonoBehaviour
{
    public Vector2 boxSize;
    private GameObject player;
    public Transform boxSpot;
    public LayerMask playerLayer;
    public bool playerCheck;
    public bool canDamage = true;
    public GameObject scythePrefab;
    public Transform spawnLoc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCheck()
    {
        playerCheck = Physics2D.OverlapBox(boxSpot.position, boxSize, 0, playerLayer);
        if (playerCheck && canDamage)
        {
            canDamage = false;
            player.GetComponent<Health>().PlayerDamage(1);
            
            StartCoroutine(DamageDelay());
        }
    }
    public void SummonAttack()
    {
        Instantiate(scythePrefab, spawnLoc.position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxSpot.position, boxSize);
    }


    IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(1.40f);
        canDamage = true;
    }
}
