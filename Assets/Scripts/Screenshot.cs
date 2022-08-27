using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            Capture();
        }
    }
    public void Capture()
    {
        ScreenCapture.CaptureScreenshot("shot");
    }
}
