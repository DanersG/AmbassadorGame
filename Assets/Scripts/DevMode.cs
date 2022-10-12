using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class DevMode: MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Minus)){
            SceneManager.LoadScene("DevRoom");
            //Debug.Log("Go to DevRoom");
        }
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            SceneManager.LoadScene("Beach");
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            SceneManager.LoadScene("Castle_Exterior");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            SceneManager.LoadScene("Castle_Interior");
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            SceneManager.LoadScene("Church_exterior");
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            SceneManager.LoadScene("Church_Interior");
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            SceneManager.LoadScene("Farm");
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)){
            SceneManager.LoadScene("Forest");
        }
        if(Input.GetKeyDown(KeyCode.Alpha7)){
            SceneManager.LoadScene("Mine_Interior");
        }
        if(Input.GetKeyDown(KeyCode.Alpha8)){
            SceneManager.LoadScene("Prison");
        }
        if(Input.GetKeyDown(KeyCode.Alpha9)){
            SceneManager.LoadScene("Wizard_Exterior");
        }
        if(Input.GetKeyDown(KeyCode.Tilde)){
            SceneManager.LoadScene("Wizard_Interior");
        }
    }
}
