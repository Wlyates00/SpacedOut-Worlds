using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetsound : MonoBehaviour
{
    private GameObject player;
    public AudioSource jetSound;
    private bool played = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        jetSound.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.transform.position.x - transform.position.x) < 10 && !played)
        {
            jetSound.Play();
            jetSound.loop = true;
            
            played = true;
        }
        else if (Mathf.Abs(player.transform.position.x - transform.position.x) > 10)
        {
            jetSound.Stop();
            played = false;
        }
    }
}
