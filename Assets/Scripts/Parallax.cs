using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    //private float height;
    private float startPosX;
    //private float startPosY;
    public float parallaxEffect;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        //startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        //height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPosX + dist, transform.position.y, transform.position.z);
    }
}
