using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public LayerMask playerLayer;
    public Vector2 boxSize;
    public bool playerTouched;
    public bool attackPlayer;
    public GameObject bossWormGate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTouched = Physics2D.OverlapBox(transform.position, boxSize, 0, playerLayer);
        if(playerTouched)
        {
            attackPlayer = true;
            bossWormGate.SetActive(true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(transform.position, boxSize);
    }
}
