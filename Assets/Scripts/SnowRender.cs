using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowRender : MonoBehaviour
{
    public GameObject snowFX;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distBTW = player.transform.position.x - transform.position.x;
        if(Mathf.Abs(distBTW) < 25)
        {
            snowFX.SetActive(true);
        }
        else if (Mathf.Abs(distBTW) > 30)
        {
            snowFX.SetActive(false);
        }
    }
}
