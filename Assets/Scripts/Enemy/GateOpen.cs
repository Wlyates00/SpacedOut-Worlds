using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public float gateSpeed;
    public Transform gate;
    public Transform boss;
    private float bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (boss == null)
        {
            gate.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), .05f);
        }
    }
}
