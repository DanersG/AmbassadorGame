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
            PlayerPrefs.SetString("LevelSaved", sceneName);
        }
    }
}
