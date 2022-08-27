using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavePlatform : MonoBehaviour
{
    public float speed;
    public Transform boxPoint;
    public Vector2 boxSize;
    public LayerMask playerLayer;
    private bool playerOn;
    private bool notMoved = true;
    private Vector3 ogPos;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        ogPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerOn = Physics2D.OverlapBox(boxPoint.position, boxSize, 0, playerLayer);
        if (playerOn && notMoved)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if(transform.position != ogPos)
            {
                notMoved = false;
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(boxPoint.position, boxSize);
    }
}
