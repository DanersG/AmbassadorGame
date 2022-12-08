using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCResponsive : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public Text responceText;
    public string[] dialogue;
    public string[] responce;
    private int index;
    private int responceTacker;

    public float wordSpeed;
    public bool playerIsClose;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
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
            else if (responceTacker == 2 && responce.Length >= 2)
            {
                responceText.text = responce[2];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    dialogueText.text = dialogue[3];
                }
            }
            else if (responceTacker == 3 && responce.Length >= 3)
            {
                responceText.text = responce[3];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    dialogueText.text = dialogue[4];
                }
            }
            else if (responceTacker == 4 && responce.Length >= 4)
            {
                responceText.text = responce[4];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    dialogueText.text = dialogue[5];
                }
            }
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