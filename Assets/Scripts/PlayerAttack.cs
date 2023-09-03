using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Updateattackstate();
           
        }
    }

    

    void Updateattackstate()
    {

        animator.SetTrigger("attack");

        Collider2D [] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitenemies)
        { Debug.Log("We hit" + enemy.name); }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}