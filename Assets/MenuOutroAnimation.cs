using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOutroAnimation : MonoBehaviour
{
    public GameObject outro;
    private bool canChange;
    public GameObject endlessOutro;
    public void OutroProtocol()
    {
        outro.SetActive(true);
        StartCoroutine("AnimationDelay");
        if (canChange)
        {
            canChange = false;

            //SceneManager.LoadScene(0);
        }
    }

    public void EndlessOutro()
    {
        endlessOutro.SetActive(true);
    }

    IEnumerator AnimationDelay()
    {
        yield return new WaitForSeconds(5);
        canChange = true;

    }
}
