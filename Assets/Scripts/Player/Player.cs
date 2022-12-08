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
    public GameObject[] reloadSlot;
    static List<GameObject> keepObjects = new List<GameObject>();
   
    private bool loaded = false;


    private void Start()
    {
        playerPos.position = scenevariables.playerPosition;
        Debug.Log(playerPos.position);
        boxCollider = GetComponent<BoxCollider2D>();
        //Debug.Log(keepObjects.Count);
    }
   
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        

        // Reset playMove
        playMove = new Vector3(x,y,0);
        // Making it move!
        transform.Translate(playMove * mainSpeed);
        /*if (Input.GetKey(KeyCode.Tab) && !loaded)
        {
            //Debug.Log("Menu");
            ReloadInventory();
            loaded = true;
        }*/
    }
    public void PickUp(GameObject item)
    {
       
        invetorySlot = GameObject.FindGameObjectsWithTag("InvetorySlot");
        //Debug.Log(invetorySlot.Length);
        keepObjects.Add(item);
        for(int i = 0; i < invetorySlot.Length; i++)
        {
            if(invetorySlot[i].transform.childCount == 0)
            {
                Debug.Log("Found Slot");
                
                GameObject InvetoryItem = GameObject.Instantiate(item);
                InvetoryItem.transform.SetParent(invetorySlot[i].transform);
                InvetoryItem.gameObject.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log(item.transform.parent.name);
                Debug.Log(invetorySlot[i].transform.childCount);
                return;
            }

        }

    }
    /*public void ReloadInventory()
    {
        Debug.Log("ReloadInventory");
        reloadSlot = GameObject.FindGameObjectsWithTag("InvetorySlot");
        int n = keepObjects.Count;
        Debug.Log(keepObj);
        for (int i = 0; i < n; i++)
        {
            Debug.Log(i);
                if (invetorySlot[i].transform.childCount == 0)
                {
                    GameObject InvetoryItem = GameObject.Instantiate(keepObjects[i]);
                    InvetoryItem.transform.SetParent(reloadSlot[i].transform);
                }
        }
    }*/
}
