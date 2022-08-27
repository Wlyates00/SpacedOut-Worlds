using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackParalax : MonoBehaviour
{
    private float length;
    private float height;
    private float startPosX;
    private float startPosY;
    public float parallaxEffectX;
    public float parallaxEffectY;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float distX = (cam.transform.position.x * parallaxEffectX);
        float distY = (cam.transform.position.y * parallaxEffectY);
        transform.position = new Vector3(startPosX + distX, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, startPosY + distY, transform.position.z);
    }
}
