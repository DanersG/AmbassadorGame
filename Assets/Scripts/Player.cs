using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 playMove;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        // Reset playMove
        playMove = new Vector3(x,y,0);

        // Swap sprite direction to either right or left.
        if (playMove.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (playMove.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        // Making it move!
        transform.Translate(playMove * Time.deltaTime);
        
    }
}
