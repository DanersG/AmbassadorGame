using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DevMode: MonoBehaviour
{
    // Start is called before the first frame update
    public Text levelLabel;
    public Vector2 targetPosition;
    private bool Active = false;
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

        //Shows or hides overlay
        levelLabel.gameObject.SetActive(Active);
        //Keeps exsisting objects from scene to scene
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftControl))
        {
            levelLabel.gameObject.SetActive(!Active);
            Active = !Active;
        }
        if (Input.GetKey(KeyCode.Minus)){
            SceneManager.LoadScene("DevRoom");
            levelLabel.text = "Dev Room 0";
            //When loading in new scene it spawns you at default (0,0)
            player.position = targetPosition;
        }
        if(Input.GetKey(KeyCode.Alpha0)){
            SceneManager.LoadScene("Beach");
            levelLabel.text = "Beach ";
            player.position = targetPosition;
        }
        if(Input.GetKey(KeyCode.Alpha1)){
            SceneManager.LoadScene("Castle_Exterior");
            levelLabel.text = "Outside Castle";
            player.position = targetPosition;
        }
        if(Input.GetKey(KeyCode.Alpha2)){
            SceneManager.LoadScene("Castle_Interior");
            levelLabel.text = "Inside Castle";
            player.position = targetPosition;
        }
        if(Input.GetKey(KeyCode.Alpha3)){
            SceneManager.LoadScene("Church_exterior");
            levelLabel.text = "Outside Church";
            player.position = targetPosition;
        }
        if(Input.GetKey(KeyCode.Alpha4)){
            SceneManager.LoadScene("Church_Interior");
            levelLabel.text = "Inside Church";
            player.position = targetPosition;
        }
        if(Input.GetKey(KeyCode.Alpha5)){
            SceneManager.LoadScene("Farm");
            levelLabel.text = "Farm";
            player.position = targetPosition;
        }
        if(Input.GetKey(KeyCode.Alpha6)){
            SceneManager.LoadScene("Forest");
            levelLabel.text = "Forest";
            player.position = targetPosition;
        }
        if(Input.GetKey(KeyCode.Alpha7)){
            SceneManager.LoadScene("Mine_Interior");
            levelLabel.text = "Mine";
            player.position = targetPosition;
        }
        if(Input.GetKey(KeyCode.Alpha8)){
            SceneManager.LoadScene("Prison");
            levelLabel.text = "Prison";
            player.position = targetPosition;
        }
        if(Input.GetKey(KeyCode.Alpha9)){
            SceneManager.LoadScene("Wizard_Exterior");
            levelLabel.text = "Outside Wizard Hut";
            player.position = targetPosition;
        }
        if(Input.GetKey(KeyCode.Tilde)){
            SceneManager.LoadScene("Wizard_Interior");
            levelLabel.text = "Inside Wizard Hut";
            player.position = targetPosition;
        }
        if (Input.GetKey(KeyCode.Equals))
        {
            SceneManager.LoadScene("Boss Arena");
            levelLabel.text = "Inside Boss Arena";
            
        }
    }
}
