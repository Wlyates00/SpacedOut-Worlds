using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    public Slider slider;
    public static float slideValue;
    private Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider != null)
        {
            slider.onValueChanged.AddListener(delegate { changeVolume(slider.value); }); ;
            slideValue = slider.value;
        }
        else
        {
            return;
        }
       
        SaveVolume();
    }
    

    void changeVolume(float sliderValue)
    {
        cam.GetComponent<AudioSource>().volume = sliderValue;
        
    }

    void SaveVolume()
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
    }
}
