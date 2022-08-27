using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private bool canChangeLevels;
    private bool canChangeEndless;
    public void Update()
    {
        if (canChangeLevels)
        {
            SceneManager.LoadScene(1);
        }
        if (canChangeEndless)
        {
            SceneManager.LoadScene(3);
        }
    }
    public void PlayButton()
    {
        StartCoroutine("LevelsAnimationDelay");
    }

    public void EndlessButton()
    {
        StartCoroutine("EndlessAnimationDelay");
    }

    IEnumerator LevelsAnimationDelay()
    {
        yield return new WaitForSeconds(5);
        canChangeLevels = true;

    }

    IEnumerator EndlessAnimationDelay()
    {
        yield return new WaitForSeconds(5);
        canChangeEndless = true;

    }
}
