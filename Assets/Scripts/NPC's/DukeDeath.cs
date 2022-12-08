using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DukeDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void OnDestroy()
    {
        Debug.Log("Duke Died");
        SceneManager.LoadScene("AfterDefeat");
    }

    // Update is called once per frame
  
}
