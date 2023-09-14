using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health;
    // Start is called before the first frame update
    private Animator anim; //declaring variables
    void Start()
    {
        health = 100f;
        anim = GetComponent<Animator>(); //accessing the animator component and setting the enemy initial health to 100
    }

    
    public void EnemyTakeDamage (float damageEnemy)
    {
        
        
           health -= damageEnemy; //health - damage
        
           if (health <= 0)
        {
            Die(); //if health reach 0 it calls this function
            
        }
        
    }

    private void Die() //the death trigger is triggered so the enemy goblin performs the death animation
    {
        anim.SetTrigger("death");
        Debug.Log("enemy died");
        
        
    }

    public void vanish()
    {
        Destroy(gameObject); //the goblin gets destroyed so that it doesn't exist in the scene anymore
    }
}
