using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EndlessScore : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int enemiesKilled = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Spawners") != null)
        {
            score.text = "Killed" +" "+ enemiesKilled;
        }
        
        
    }

    
}
