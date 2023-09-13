using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Transform attackpoint;
    private Animator anim;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    private bool damageApplied = false;
    void Start()
    {
   
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
          

            // Use OverlapBoxAll to find all colliders within the specified box

          
            Vector2 boxSize = new Vector2(attackRange, attackRange);
            
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackpoint.position, boxSize, enemyLayers);

                // Now, hitEnemies contains all the enemies within the range of the BoxCollider2D.
                // You can loop through hitEnemies to perform actions on each enemy if needed.
                foreach (Collider2D enemy in hitEnemies)
                {

                if (enemy != null)
            {
                // Check if damage has already been applied during this attack
                    if (!damageApplied)
                    {
                    Enemy enemyComponent = enemy.GetComponent<Enemy>();
                    if (enemyComponent != null)
                    {
                        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 1"))
                        {
                            enemyComponent.EnemyTakeDamage(10);
                            Debug.Log("We hit the enemy 10");
                        }
                        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 2"))
                        {
                            enemyComponent.EnemyTakeDamage(10);
                            Debug.Log("We hit the enemy 10");
                        }
                        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 3"))
                        {
                            enemyComponent.EnemyTakeDamage(30);
                            Debug.Log("We hit the enemy 30");
                        }
                    }
                        damageApplied = true; // Set the flag to true to indicate damage has been applied
                    }
            }
        }
            
     }
   void OnDrawGizmosSelected()
    {
        Vector2 boxSize = new Vector2(attackRange, attackRange);
        Gizmos.DrawWireCube(attackpoint.position, boxSize);
     
    }
    void OnAnimationEnd() // Adjust the event name to match your animation event name
    {
        damageApplied = false; // Reset the flag when the animation ends
    }




}




  

