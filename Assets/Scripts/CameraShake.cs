using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera cam;
    float shakeAmt = 0;

    private void Awake()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    public void Shake(float amt, float length)
    {
        shakeAmt = amt;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void DoShake()
    {
        if (shakeAmt > 0)
        {
            Vector3 camPos = cam.transform.position;

            float x = Random.value * shakeAmt * 2 - shakeAmt;
            float y = Random.value * shakeAmt * 2 - shakeAmt;
            camPos.x += x;
            camPos.y += y;

            cam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        cam.transform.localPosition = Vector3.zero;
    }
}
