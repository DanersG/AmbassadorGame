using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public Vector2 targetPosition;
    public Transform player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name == "Farm Trigger")
        {
            SceneManager.LoadScene("Farm");
            player.position = targetPosition;
        }
        else if (gameObject.name == "Town Trigger")
        {
            SceneManager.LoadScene("Town");
            player.position = targetPosition;
        }
        else if (gameObject.name == "Castle Trigger")
        {
            SceneManager.LoadScene("Castle_Exterior");
            player.position = targetPosition;
        }
        else if (gameObject.name == "Church Trigger")
        {
            SceneManager.LoadScene("Church_exterior");
            player.position = targetPosition;
        }
        else if (gameObject.name == "Forest Trigger")
        {
            SceneManager.LoadScene("Forest");
            player.position = targetPosition;
        }
        else if (gameObject.name == "Beach Trigger")
        {
            SceneManager.LoadScene("Beach");
            player.position = targetPosition;
        }
        else if (gameObject.name == "Mine Trigger")
        {
            SceneManager.LoadScene("Mine_Interior");
            player.position = targetPosition;
        }
        else if (gameObject.name == "Prison Trigger")
        {
            SceneManager.LoadScene("Prison");
            player.position = targetPosition;
        }
        else if (gameObject.name == "Sewer Trigger")
        {
            SceneManager.LoadScene("Sewer");
            player.position = targetPosition;
        }
        else if (gameObject.name == "Wizard Trigger")
        {
            SceneManager.LoadScene("Wizard_Exterior");
            player.position = targetPosition;
        }
    }
}
