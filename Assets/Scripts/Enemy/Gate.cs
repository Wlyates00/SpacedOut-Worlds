using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public float gateDamage;
    public Transform player;
    public LayerMask playerLayer;
    public LayerMask groundLayer;
    public Transform gateBottom;
    public Vector2 boxSize;
    public Transform boxPos;
    public bool gateTriggered;
    private Rigidbody2D rb;
    public bool groundedGate = false;
    public bool underGate = false;
    public float radius;
    public Transform cam;
    private bool ground = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        groundedGate = Physics2D.OverlapCircle(gateBottom.position, radius, groundLayer);
        if (groundedGate && ground)
        {
            ground = false;
            
        }
        underGate = Physics2D.OverlapCircle(gateBottom.position, radius, playerLayer);
        if (underGate)
        {
            player.GetComponent<Health>().PlayerDamage(gateDamage);
        }
        //if(player.position.x > transform.position.x)
        //{
        //    GetComponent<Rigidbody2D>().isKinematic = false;
        //}
        gateTriggered = Physics2D.OverlapBox(boxPos.position, boxSize, 0, playerLayer);
        if(gateTriggered)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gateBottom.position, radius);
        Gizmos.color = Color.red;
        Gizmos.DrawCube(boxPos.position, boxSize);
    }
    
}
