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
    public Transform playerPos;
    public GameObject[] invetorySlot;


    private void Start()
    {
        playerPos.position = scenevariables.playerPosition;
        Debug.Log(playerPos.position);
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
    public void PickUp(GameObject item)
    {
       
        invetorySlot = GameObject.FindGameObjectsWithTag("InvetorySlot");
        //Debug.Log(invetorySlot.Length);
        for(int i = 0; i < invetorySlot.Length; i++)
        {
            if(invetorySlot[i].transform.childCount == 0)
            {
                Debug.Log("Found Slot");
                
                GameObject InvetoryItem = GameObject.Instantiate(item);
                InvetoryItem.transform.SetParent(invetorySlot[i].transform);
                Debug.Log(item.transform.parent.name);
                Debug.Log(invetorySlot[i].transform.childCount);
                return;
            }

        }
    }
}
