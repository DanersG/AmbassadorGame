using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    private float nextAttackTime =0f;
    public float attackDelay = .5f;
    [SerializeField] private AudioSource swordSlash;
    [SerializeField] private AudioSource walkOnGrass;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void StopAll(){
            anim.SetBool("walkRight", false);
            anim.SetBool("walkLeft", false);
            anim.SetBool("walkBack", false);
            anim.SetBool("walkFront", false);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            StopAll();
            anim.SetBool("walkFront", true);

            //PLAY footsteps sound effect
            if(!walkOnGrass.isPlaying)
                walkOnGrass.Play();

            //Attack while walking    
            if(Input.GetKey(KeyCode.Space)){
                anim.SetBool("walkFront", false);
                anim.SetBool("spinAttack", true);
                swordSlash.Play();
            }
            else{
                anim.SetBool("spinAttack", false);
            }
        }

        else if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
           StopAll();
           anim.SetBool("walkBack", true);

           //PLAY footsteps sound effect
           if(!walkOnGrass.isPlaying)
                walkOnGrass.Play();

           //Attack while walking
           if(Input.GetKey(KeyCode.Space)){
                anim.SetBool("walkBack", false);
                anim.SetBool("spinAttack", true);
                swordSlash.Play();
            }
            else{
                anim.SetBool("spinAttack", false);
            }
        }

        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
           StopAll();
           anim.SetBool("walkLeft", true);
           
           //PLAY footsteps sound effect
           if(!walkOnGrass.isPlaying){
                walkOnGrass.Play();
                Debug.Log("Playing sound");
           }

           //Attack while walking
           if(Input.GetKey(KeyCode.Space)){
                anim.SetBool("walkLeft", false);
                anim.SetBool("spinAttack", true);
                swordSlash.Play();
            }
            else{
                anim.SetBool("spinAttack", false);
            }
        }

        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
           StopAll();
           anim.SetBool("walkRight", true);

           //PLAY footsteps sound effect
           if(!walkOnGrass.isPlaying)
                walkOnGrass.Play();

           //Attack while walking
           if(Input.GetKey(KeyCode.Space)){
                anim.SetBool("walkRight", false);
                anim.SetBool("spinAttack", true);
                swordSlash.Play();
            }
            else{
                anim.SetBool("spinAttack", false);
            }
        }
        //Stop walk & SoundFX footsteps
        else{
            walkOnGrass.Stop();
            StopAll();
        }

        //Attack
        if(Input.GetKey(KeyCode.Space) && Time.time >= nextAttackTime){
           anim.SetBool("spinAttack", true);
           swordSlash.Play();
            nextAttackTime = Time.time + attackDelay;
        }
        //Stop attack
        else{
            anim.SetBool("spinAttack", false);
        }
        
        
    }
}
