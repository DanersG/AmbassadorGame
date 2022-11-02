using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
   
     // Update is called once per frame
    public void QuitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
}
