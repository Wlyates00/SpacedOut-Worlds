using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndlessManager : MonoBehaviour
{
    private GameObject player;
    public float score;
    public float highscore;
    public string displayText;
    private bool changed;
    public GameObject spawners;
    static EndlessManager instance;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //displayText = PlayerPrefs.GetString("Highscore");
        if (PlayerPrefs.GetString("Highscore") != null)
        {
            displayText = PlayerPrefs.GetString("Highscore");
        }
        if (instance == null)
        {
            instance = this; // In first scene, make us the singleton.
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        spawners = GameObject.FindGameObjectWithTag("Spawners");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if(spawners == null)
            {
                spawners = GameObject.FindGameObjectWithTag("Spawners");
            }
            changed = true;
            score = spawners.GetComponent<EndlessScore>().enemiesKilled;
            if (score >= highscore)
            {
                highscore = score;
                PlayerPrefs.SetString("Highscore", highscore.ToString());
            
                if(player == null || player.GetComponent<Health>().currentHealth <= 0)
                {
                    displayText = "Highscore" + " " + highscore.ToString();
                
                    PlayerPrefs.Save();
                }

            }            
        }

    }
}
