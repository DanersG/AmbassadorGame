using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    ItemGiver ItemGiver;

    public GameObject dialoguePanel;
    public Text dialogueText;
    public Text responceText;
    public string[] dialogue;
    public string[] responce;
    private int index;
    private int responceTacker;

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

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            responceTacker++;
            if(responceTacker >= responce.Length - 1)
            {
                responceTacker = responce.Length - 1;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            responceTacker--;
            if (responceTacker < 0)
            {
                responceTacker = 0;
            }
        }

        //Checks to see if all the text is written out
        if (dialogueText.text == dialogue[index])
        {
            giveButton.SetActive(true);
            //If this is the first time interacting
            if (responceTacker == 0 && responce.Length >= 0)
            {
                responceText.text = responce[0];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    dialogueText.text = dialogue[1];
                }
            }
            else if (responceTacker == 1 && responce.Length >= 1)
            {
                responceText.text = responce[1];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    dialogueText.text = dialogue[2];
                }
            }
            //contButton.SetActive(true);
            //giveButton.SetActive(true);
        }
    }

    private void zeroText()
    {
        dialogueText.text = "";
        responceText.text = "";
        index = 0;
        responceTacker = 0;
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