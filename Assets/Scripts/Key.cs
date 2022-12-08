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

	// Use this for initialization
    // Used for ingame text prompt
	/*private void Start () {
        pickUpText.gameObject.SetActive(false);
	}*/

	// Update is called once per frame
	private void Update () {
        //emorataya: Saving System test
        if(PlayerPrefs.GetString(collectableId) == "collected") {
            PickUp();
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

    private void PickUp()
    {
        //emorataya: Saving System test
        PlayerPrefs.SetString(collectableId, "collected");
        Destroy(gameObject);
    }

}
