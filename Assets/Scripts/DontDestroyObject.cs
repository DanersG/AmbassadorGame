using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestroyObject : MonoBehaviour
{
    Scene currentScence;
   private void Awake()
    {
        currentScence = SceneManager.GetActiveScene ();
        if(currentScence.name != "deathScreen" && currentScence.name != "Main Menu"){
            DontDestroyOnLoad(gameObject);
        }
    }
}
