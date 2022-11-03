using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            anim.SetBool("walkFront", true);
        }
        else{
            anim.SetBool("walkFront", false);
        }

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
           anim.SetBool("walkBack", true);
        }
        else{
            anim.SetBool("walkBack", false);
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
           anim.SetBool("walkLeft", true);
        }
        else{
            anim.SetBool("walkLeft", false);
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
           anim.SetBool("walkRight", true);
        }
        else{
            anim.SetBool("walkRight", false);
        }

    }
}
