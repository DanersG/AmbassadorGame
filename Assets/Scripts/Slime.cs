using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Slime : MonoBehaviour
{
    public Transform attackPoint;
    public Transform sightPoint;
    public float attackRange = 2f;
    public float sightRange = 4f;
    public float trackRange = 8f;
    public float sightRangeOrigin = 4f;
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
        Collider2D Sight = Physics2D.OverlapCircle(sightPoint.position, sightRange, playerLayer);
        if(Sight != null)
        {
            
            sightRange = trackRange;
            this.GetComponent<AIDestinationSetter>().target = Sight.GetComponent<Player>().transform;
            
        }
        else
        {
            sightRange = sightRangeOrigin;
            this.GetComponent<AIDestinationSetter>().target = null;
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
    private void OnDrawGizmos()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(sightPoint.position, sightRange);

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
