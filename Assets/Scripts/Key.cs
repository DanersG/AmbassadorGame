using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

    [SerializeField]
    //private Text pickUpText;

    private bool pickUpAllowed;
    //emorataya: Saving System test
    public string collectableId;
    public string sceneName;
    public Transform pickUpSpot;
    public float pickUpRange = 1f;
    public LayerMask playerLayer;

    // Use this for initialization
    // Used for ingame text prompt
    /*private void Start () {
        pickUpText.gameObject.SetActive(false);
	}*/

    // Update is called once per frame
    private void Update () {
        //emorataya: Saving System test
        if(PlayerPrefs.GetString(collectableId) == "collected") {
            //PickUp();
        }

        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            //pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            //pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

        }
    }

    private void OnDrawGizmos()
    {
        if (pickUpSpot == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(pickUpSpot.position, pickUpRange);
    }

    private void PickUp()
    {
        //emorataya: Saving System test
        PlayerPrefs.SetString(collectableId, "collected");
        Collider2D player = Physics2D.OverlapCircle(pickUpSpot.position, pickUpRange, playerLayer);
        GameObject item = this.gameObject;
        player.GetComponent<Player>().PickUp(item);
        Destroy(this.gameObject);
    }

}

