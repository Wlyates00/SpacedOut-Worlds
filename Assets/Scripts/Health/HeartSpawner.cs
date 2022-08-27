using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public Transform loc1;
    public Transform loc2;
    public GameObject heartPrefab;
    public float heartSpawnDelay;
    private bool canSpawn;
    private bool giveNumber = true;
    public int variableR;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NumberGenerator();
        HeartSpawn();
    }
    void HeartSpawn()
    {
        int x = Random.Range(1, 2);
        if (variableR == 3 && canSpawn)
        {
            if (x == 1)
            {
                Instantiate(heartPrefab, loc1.position, Quaternion.identity);
                canSpawn = false;
            }
            else if (x == 2)
            {
                Instantiate(heartPrefab, loc2.position, Quaternion.identity);
                canSpawn = false;
            }
        }
    }
    void NumberGenerator()
    {
        if (giveNumber)
        {
            variableR = Random.Range(1, 10);
            if(variableR == 3)
            {
                canSpawn = true;
            }
            giveNumber = false;
            StartCoroutine("NumberGen");
        }
        

    }

    IEnumerator NumberGen()
    {
        yield return new WaitForSeconds(2.5f);
        giveNumber = true;
    }
    IEnumerator GenDelay()
    {
        yield return new WaitForSeconds(2.6f);
        canSpawn = true;
    }
}
