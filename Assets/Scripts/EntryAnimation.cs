using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryAnimation : MonoBehaviour
{
    public float delay;
    private bool disable;
    public GameObject whiteScreen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Delay");
    }

    // Update is called once per frame
    void Update()
    {
        if (disable)
        {
            whiteScreen.SetActive(false);
            disable = false;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        disable = true;
    }
}
