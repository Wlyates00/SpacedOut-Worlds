using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawnTrigger : MonoBehaviour
{
    
    private bool hasSpawned;
    public GameObject bombPrefab;
    public Transform spawnSpot;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x <= transform.position.x && !hasSpawned)
        {
            Instantiate(bombPrefab, spawnSpot.position, Quaternion.identity);
            hasSpawned = true;
        }
    }
}
