using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBeaten : MonoBehaviour
{
    public float timeBTWScenes;
    public GameObject bossBeatScreen;
    private bool canChange;
    public GameObject boss;


    private void Update()
    {
        if (boss == null)
        {
            bossBeatScreen.SetActive(true);
            StartCoroutine("AnimationDelay");
            if (canChange)
            {
                canChange = false;

                SceneManager.LoadScene(2);
            }
        }
        else if (boss.GetComponent<FirstBoss>().health <= 0)
        {
            bossBeatScreen.SetActive(true);
            StartCoroutine("AnimationDelay");
            if (canChange)
            {
                canChange = false;

                SceneManager.LoadScene(2);
            }
        }
    }
    public void SwitchLevels()
    {
        if(boss.GetComponent<FirstBoss>().health <= 0)
        {
            bossBeatScreen.SetActive(true);
            StartCoroutine("AnimationDelay");
            if(canChange)
            {
                canChange = false;

                SceneManager.LoadScene(2);
            }
        }
        else if(boss == null)
        {
            bossBeatScreen.SetActive(true);
            StartCoroutine("AnimationDelay");
            if (canChange)
            {
                canChange = false;

                SceneManager.LoadScene(2);
            }
        }
        
    }
    
    IEnumerator AnimationDelay()
    {
        yield return new WaitForSeconds(timeBTWScenes);
        canChange = true;

    }
}
