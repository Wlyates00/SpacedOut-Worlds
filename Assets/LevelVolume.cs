using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVolume : MonoBehaviour
{
    VolumeSlider slider;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
        cam.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
