using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DevMode: MonoBehaviour
{
    // Start is called before the first frame update
    public Text levelLabel;
    private bool Active = false;

    // Update is called once per frame
    void Awake()
    {
        GameObject[] findPlayer = GameObject.FindGameObjectsWithTag("Player");

        int thingyCount = findPlayer.Length;

        if (thingyCount > 1)
        {
            Destroy(this.gameObject);
        }

        levelLabel.gameObject.SetActive(Active);
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftControl))
        {
            levelLabel.gameObject.SetActive(!Active);
            Active = !Active;
            //DontDestroyOnLoad(this.gameObject);
        }
        if (Input.GetKey(KeyCode.Minus)){
            SceneManager.LoadScene("DevRoom");
            levelLabel.text = "Dev Room 0";
        }
        if(Input.GetKey(KeyCode.Alpha0)){
            SceneManager.LoadScene("Beach");
            levelLabel.text = "Beach ";
        }
        if(Input.GetKey(KeyCode.Alpha1)){
            SceneManager.LoadScene("Castle_Exterior");
            levelLabel.text = "Outside Castle";
        }
        if(Input.GetKey(KeyCode.Alpha2)){
            SceneManager.LoadScene("Castle_Interior");
            levelLabel.text = "Inside Castle";
        }
        if(Input.GetKey(KeyCode.Alpha3)){
            SceneManager.LoadScene("Church_exterior");
            levelLabel.text = "Outside Church";
        }
        if(Input.GetKey(KeyCode.Alpha4)){
            SceneManager.LoadScene("Church_Interior");
            levelLabel.text = "Inside Church";
        }
        if(Input.GetKey(KeyCode.Alpha5)){
            SceneManager.LoadScene("Farm");
            levelLabel.text = "Farm";
        }
        if(Input.GetKey(KeyCode.Alpha6)){
            SceneManager.LoadScene("Forest");
            levelLabel.text = "Forest";
        }
        if(Input.GetKey(KeyCode.Alpha7)){
            SceneManager.LoadScene("Mine_Interior");
            levelLabel.text = "Mine";
        }
        if(Input.GetKey(KeyCode.Alpha8)){
            SceneManager.LoadScene("Prison");
            levelLabel.text = "Prison";
        }
        if(Input.GetKey(KeyCode.Alpha9)){
            SceneManager.LoadScene("Wizard_Exterior");
            levelLabel.text = "Outside Wizard Hut";
        }
        if(Input.GetKey(KeyCode.Tilde)){
            SceneManager.LoadScene("Wizard_Interior");
            levelLabel.text = "Inside Wizard Hut";
        }
    }
}
