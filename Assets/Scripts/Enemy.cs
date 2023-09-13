using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health;
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        health = 100f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyTakeDamage (float damageEnemy)
    {
        
        
           health -= damageEnemy;
        
           if (health <= 0)
        {
            Die();
            
        }
        
    }

    private void Die()
    {
        anim.SetTrigger("death");
        Debug.Log("enemy died");
        
        
    }

    public void vanish()
    {
        Destroy(gameObject);
    }
}
