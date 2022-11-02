using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public int maxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void FixedUpdate()
    {
        Collider2D player = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
        if(player != null)
        {
            player.GetComponent<PlayerCombat>().TakeDamage(10);
        }
    }
    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Play hurt animation

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Slime has died");

        // animation

        // diable enemy 
       
        GetComponent<Collider2D>().enabled = false;

        Destroy(this.gameObject);



    }
}
