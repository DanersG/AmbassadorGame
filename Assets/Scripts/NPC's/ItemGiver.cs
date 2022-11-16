using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    public GameObject itemToGive;
    public bool playerIsClose;
    public GameObject[] items;
    public GameObject[] invetorySlot;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;

            //Checks for Items in invetory
            items = GameObject.FindGameObjectsWithTag("Items");
            invetorySlot = GameObject.FindGameObjectsWithTag("InvetorySlot");
            //Searches all items in invetory
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].name == "sword")
                {
                    //Searches all slots in invetory
                    for (int x = 0; x < invetorySlot.Length; x++)
                    {
                        if(invetorySlot[i].transform.childCount == 0)
                        {
                            
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
