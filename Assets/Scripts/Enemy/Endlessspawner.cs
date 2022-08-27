using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endlessspawner : MonoBehaviour
{
    public float initalDelay;
    private bool animDelay;

    public Transform rockSpawner1;
    public Transform rockSpawner2;
    public Transform ufoSpawner1;
    public Transform ufoSpawner2;
    public Transform duoSpawner5;
    public Transform duoSpawner6;
    public Transform wormSpawner1;
    public Transform wormSpawner2;

    public GameObject snowBallPrefab;
    public GameObject bomba;
    public GameObject ufo;
    public GameObject rockfish;

    public float spawnDelay;
    private bool hasSpawned;

    private GameObject player;

    private bool delayChange;
    private bool delayChangeTwo;
    private bool delayChangeThree;

    public float spawnCount = 0;

    private GameObject spawners;

    public GameObject spawnIncreaseAnim1;
    public GameObject spawnIncreaseAnim2;
    public GameObject spawnIncreaseAnim3;

    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawners = GameObject.FindGameObjectWithTag("Spawners");
        
        StartCoroutine("AnimDelay");
    }

    // Update is called once per frame
    void Update()
    {
        if (animDelay)
        {
            RandomSpawnPhase1();
            if(spawners.GetComponent<EndlessScore>().enemiesKilled >= 10 && !delayChange)
            {
                delayChange = true;
                spawnDelay = spawnDelay / 1.6f;
                if(spawnIncreaseAnim1 != null)
                {
                    spawnIncreaseAnim1.SetActive(true);
                }


            }
            else if (spawners.GetComponent<EndlessScore>().enemiesKilled >= 20 && !delayChangeTwo)
            {
                delayChangeTwo = true;
                spawnDelay = spawnDelay / 1.6f;
                if (spawnIncreaseAnim2 != null)
                {
                    spawnIncreaseAnim2.SetActive(true);
                }
            }
            else if (spawners.GetComponent<EndlessScore>().enemiesKilled >= 30 && !delayChangeThree)
            {
                delayChangeThree = true;
                spawnDelay = spawnDelay / 1.6f;
                if (spawnIncreaseAnim3 != null)
                {
                    spawnIncreaseAnim3.SetActive(true);
                }
            }
        }
        

    }

    public void RandomSpawnPhase1()
    {
        if(!hasSpawned && player != null)
        {
            hasSpawned = true;
            int x1 = Random.Range(1, 6);
            int y1 = Random.Range(1, 2);
            spawnCount += 1;
            
            
            if (x1 == 1)
            {
                var spawnLoc = duoSpawner6;
                
                if (y1 == 1)
                {
                    Instantiate(snowBallPrefab, spawnLoc.position, Quaternion.identity);
                }
                else if (y1 == 2)
                {
                    Instantiate(bomba, spawnLoc.position, Quaternion.identity);
                }
            }
            else if (x1 == 2)
            {
                var spawnLoc = duoSpawner5;
                
                if (y1 == 1)
                {
                    Instantiate(snowBallPrefab, spawnLoc.position, Quaternion.identity);
                }
                else if (y1 == 2)
                {
                    Instantiate(bomba, spawnLoc.position, Quaternion.identity);
                }
            }
            else if (x1 == 3)
            {
                var spawnLoc = rockSpawner1;
                Instantiate(rockfish, spawnLoc.position, Quaternion.identity);
            }
            else if (x1 == 4)
            {
                var spawnLoc = rockSpawner2;
                Instantiate(rockfish, spawnLoc.position, Quaternion.identity);
            }
            else if (x1 == 5)
            {
                var spawnLoc = ufoSpawner1;
                Instantiate(ufo, spawnLoc.position, Quaternion.identity);
            }
            else if (x1 == 6)
            {
                var spawnLoc = ufoSpawner2;
                Instantiate(ufo, spawnLoc.position, Quaternion.identity);
            }
            StartCoroutine("SpawnDelay");
        }
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        hasSpawned = false; 
    }

    IEnumerator AnimDelay()
    {
        yield return new WaitForSeconds(initalDelay);
        animDelay = true;
    }
}
