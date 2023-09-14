using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Transform attackpoint;
    private Animator anim;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    private bool damageApplied = false; //declaring variables
    void Start()
    {
   
        anim = GetComponent<Animator>(); //accessing the animator component
    }

  
    void Update()
    {
        
          

            // Use OverlapBoxAll to find all colliders within the specified box

          
            Vector2 boxSize = new Vector2(attackRange, attackRange); //defines the box size
            
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackpoint.position, boxSize, enemyLayers); // the hitEnemies contains all the enemies within the range of the Box.


     
        foreach (Collider2D enemy in hitEnemies) // loop through hitEnemies to perform actions on each enemy
        {

                if (enemy != null) //if the enemy exists
            {
                // Check if damage has already been applied during this attack
                    if (!damageApplied)
                    {
                    Enemy enemyComponent = enemy.GetComponent<Enemy>(); //accesses the enemy script
                    if (enemyComponent != null) //if the enemy component exists
                    {
                        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 1")) //if it is attack 1, then 10 damage is dealt
                        {
                            enemyComponent.EnemyTakeDamage(10);
                            Debug.Log("We hit the enemy 10");
                        }
                        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 2"))//if it is attack 2, then 10 damage is dealt
                        {
                            enemyComponent.EnemyTakeDamage(10);
                            Debug.Log("We hit the enemy 10");
                        }
                        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 3")) //if it is attack 3, then 30 damage is dealt
                        {
                            enemyComponent.EnemyTakeDamage(30);
                            Debug.Log("We hit the enemy 30");
                        }
                    }
                        damageApplied = true; // Set the bool to true to indicate damage has been applied
                    }
            }
        }
            
     }
   void OnDrawGizmosSelected() //basically enables me to see the actual box(hitbox) of the player
    {
        Vector2 boxSize = new Vector2(attackRange, attackRange);
        Gizmos.DrawWireCube(attackpoint.position, boxSize);
     
    }
    void OnAnimationEnd() 
    {
        damageApplied = false; // at around the end of an animation, I add an animation event, and I call this method on that event, so that the damageApplied bool is set to false at the end of the attack animation
    }




}




  

