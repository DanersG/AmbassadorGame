using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    //Imports ItemGiver script
    //public ItemGiver invetory;

    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    public string[] responce;
    //public string[] questDialogue;
    private int index;

    public GameObject contButton;
    public GameObject giveButton;
    public float wordSpeed;
    public bool playerIsClose;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            contButton.SetActive(false);
            giveButton.SetActive(false);
            if(dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }

        }

        if(dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
            giveButton.SetActive(true);
        }
    }

    private void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    public void QuestCheck()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = false;
        }    

        zeroText();
    }

}