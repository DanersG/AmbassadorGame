using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    public GameObject itemToGive;
    public bool playerIsClose;
    public GameObject[] items;
    public GameObject[] invetorySlot;
    //public GameObject child;
    public bool foundBrokenSword;


   public void FindItem()
    {
        if (playerIsClose)
        {
            //Checks for Items in invetory
            items = GameObject.FindGameObjectsWithTag("Items");
            invetorySlot = GameObject.FindGameObjectsWithTag("InvetorySlot");

            //Searches all items in invetory
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].name == "Broken Sword")
                {
                    foundBrokenSword = true;
                    TradeItem(i);
                }
            }
        }
    }

    void TradeItem(int i)
    {
        //Searches all slots in invetory
        Destroy(items[i]);
        for (int x = 0; x < invetorySlot.Length; x++)
        {
            Debug.Log(invetorySlot[x].transform.childCount);

            //Checks to see if invetory slot is open if not move to next
            if (invetorySlot[x].transform.childCount == 0)
            {
                //If so drop item into invetory slot
                itemToGive.transform.SetParent(invetorySlot[x].transform);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            foundBrokenSword = false;
        }
    }
}
