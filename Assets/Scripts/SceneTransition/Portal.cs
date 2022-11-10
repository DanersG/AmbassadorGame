/* using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; */

/**
From: https://www.youtube.com/watch?v=b8YUfee_pzc
Minute 2:08:01
**/

/* public class Portal : Collidable
{
    public string collidedObject;
    public string sceneName;
    public Vector2 targetPosition;
    public Transform player;

        // Update is called once per frame
    void Awake()
    {
        //Keeps exsisting objects from scene to scene
        DontDestroyOnLoad(player);
    }

    protected override void OnCollide(Collider2D coll) {
        //Finds player game object
        GameObject[] findPlayer = GameObject.FindGameObjectsWithTag("Player");

        if (coll.name == "Player") {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            Debug.Log(coll.gameObject);
            Debug.Log(coll.name);
            Debug.Log(collidedObject);
            Debug.Log(targetPosition.x);
            Debug.Log(targetPosition.y);

            if(collidedObject == "BeachNorth"){
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
                player.position = targetPosition;
            }
            else if (collidedObject == "BeachWest"){
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
                player.position = targetPosition;
            }
            else if (collidedObject == "BeachPortal"){
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
                player.position = targetPosition;
            }
        }
    }
} */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
From: https://www.youtube.com/watch?v=b8YUfee_pzc
Minute 2:08:01
**/

public class Portal : Collidable
{
    public string sceneName;
    public Vector3 targetPosition;
    public Transform player;

    // Update is called once per frame
    void Awake()
    {
        //Finds player game object
        GameObject[] findPlayer = GameObject.FindGameObjectsWithTag("Player");
        
        int playerCount = findPlayer.Length;

        //Checks to see if there is more then one player on screen
        if (playerCount > 1)
        {
            //If so deletes all but one player
            Destroy(this.gameObject);
        }

        //Keeps exsisting objects from scene to scene
        DontDestroyOnLoad(gameObject);
    }

    protected override void OnCollide(Collider2D coll) {
        if (coll.name == "Player") {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            scenevariables.playerPosition = targetPosition;
            Debug.Log("Esta llegando aqui");
        }
    }
}
