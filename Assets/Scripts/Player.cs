using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public float mainSpeed;
    private Vector3 playMove;
    private int health;
    private int maxHealth;


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
        
        // Making it move!
        transform.Translate(playMove * mainSpeed);
    }

    
}
