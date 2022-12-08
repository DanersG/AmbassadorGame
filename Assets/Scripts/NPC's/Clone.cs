//Nathan Bradley
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public Transform attackPoint;
    public Vector2 attackRangePoint1;
    public Vector2 attackRangePoint2;
    public LayerMask playerLayer;
    public float attackSpeed = 2f;
    private float attackmotion = 1f;
    private float nextAttackTime = 2f;
    private float attack = 1000f;
    public float attackRate = 1f;
    private float clear = 1000f;
    private int randomNumber;
    public int rate;
    public Sprite empty;
    public Sprite preFire;
    public Sprite Beam;
    public float AttackRange  = 1f;
    // Start is called before the first frame update
    void Start()
    {
        attackPoint.gameObject.GetComponent<SpriteRenderer>().sprite = empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            
            randomNumber = Random.Range(0, 4);
            if (randomNumber == 1)
            {
                nextAttackTime = Time.time + 1000;
                attackmotion = Time.time + attackSpeed;
                //Attack();
            }
            else
            {
                nextAttackTime = Time.time + 2f;
            }
        }
        else
        {
            if (Time.time >= clear)
            {
                attackPoint.gameObject.GetComponent<SpriteRenderer>().sprite = empty;
                attackmotion = Time.time + 2f;
                clear = Time.time + 1000f;
            }
            if (Time.time >= attackmotion)
            {
                attackPoint.gameObject.GetComponent<SpriteRenderer>().sprite = preFire;
                attackmotion = Time.time + 1000f;
                attack = Time.time + 2f;
            }
            if (Time.time >= attack)
            {
                attackPoint.gameObject.GetComponent<SpriteRenderer>().sprite = Beam;
                clear = Time.time + 1f;
                attack = Time.time + 1000f;
                Attack();
            }
        }

    }
    private void OnDrawGizmos()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawLine(attackRangePoint1, attackRangePoint2);

    }
    void Attack()
    {

        Collider2D player = Physics2D.OverlapArea(attackRangePoint1, attackRangePoint2, playerLayer);
        //Collider2D player = Physics2D.OverlapCircle(attackPoint.position, 10, playerLayer);
        if (player != null)
        {
            player.GetComponent<PlayerCombat>().TakeDamage(100);
            //player.GetComponent<PlayerCombat>().TakeDamage(10);
            //player.SendMessage("TakeDamage", 100);
            //Debug.Log(player.name);
            Debug.Log("Player found");
        }
        //gameObject.SendMessage("TakeDamage", 5);
    }
}
