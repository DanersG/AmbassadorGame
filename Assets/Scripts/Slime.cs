using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 2f;
    public LayerMask playerLayer;
    public int maxHealth = 100;
    public int currentHealth;
    //emorataya: Saving System test
    public string enemyId;

    void Start()
    {
        //emorataya: Saving System test
        if(PlayerPrefs.GetString(enemyId) == "Dead") {
            Die();
        }
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
        //emorataya: Saving System test
        PlayerPrefs.SetString(enemyId, "Dead");
        // animation

        // diable enemy 
       
        GetComponent<Collider2D>().enabled = false;

        Destroy(this.gameObject);



    }
}
