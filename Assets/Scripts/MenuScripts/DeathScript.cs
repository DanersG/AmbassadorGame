using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScript : MonoBehaviour
{
    public static string LastScene;
   
     // Update is called once per frame
    public static void QuitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public static void SetLast(string last){
        LastScene = last;
    }
    public static void RetryButton(){
        Debug.Log(LastScene);
        SceneManager.LoadScene(LastScene);
    }
    
}
