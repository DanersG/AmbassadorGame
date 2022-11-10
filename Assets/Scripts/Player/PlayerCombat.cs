using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
  
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.75f;
    public LayerMask enemeyLayers;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;
    private float damageRate = 2f;
    private float nextDamageTime = 1f;
    private int health;
    private int maxHealth = 100;
    Scene curr;
    DeathScript death;

    private void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //Play an attack animation 
        //animator.SetTrigger("Attack");

        // Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemeyLayers);
        

        //Damage
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Slime>().TakeDamage(20);
        }
       
        
    }
     
    private void OnDrawGizmos()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage)
    {
        if (Time.time >= nextDamageTime)
        {
            health -= damage;
            nextDamageTime = Time.time + 1f / damageRate;
            Debug.Log("Player health is now " + health);
        }
        if (health <= 0)
        {
            PlayerDies();
        }

    }
    void PlayerDies()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        DeathScript.SetLast(SceneManager.GetActiveScene().name);
        //gameObject.SendMessage("SetLast", curr);
        //gameObject.GetComponent<DeathScript>().SetLast(currentScence);
        health = maxHealth;
        SceneManager.LoadScene("deathScreen");
    }
   

}
