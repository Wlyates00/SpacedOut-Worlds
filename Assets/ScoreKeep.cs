using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeep : MonoBehaviour
{
    public GameObject manager;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = manager.GetComponent<EndlessManager>().displayText;
    }
}
