using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;
    private float attackCd = 0f;
    private float attackDuration1; //how long the first attack takes
    private float attackDuration2; //how long the second attack in the combo takes
    private float transitionDuration1; //the time of transition of attack 1 to attack 2, if the player did not left click before this time reaches 0, the player goes back to idle
    private float transitionDuration2; //same as attack 1, except it's from attack 2 to attack 3

    private int AttackSeq;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Start()
    {
        AttackSeq = 1;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Check();

        Attack();

    }




    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && attackCd < 0.2f)
        {
            AttackSeq = 1;

            if (AttackSeq == 1)
            {
                Attack1();
                attackCd = 0.4f;

            }
            attackDuration1 -= Time.deltaTime;
            transitionDuration1 -= Time.deltaTime;
            if (transitionDuration1 < 0)
            {
                AttackSeq = 1;
            }
            if (AttackSeq == 2 && attackDuration1 < 0 && transitionDuration1 > 0)
            {
                // Check for the transition to Attack2 when AttackSeq is 2
                Attack2();
            }
            attackDuration2 -= Time.deltaTime;
            transitionDuration2 -= Time.deltaTime;

            if (AttackSeq == 3 && attackDuration2 < 0 && transitionDuration2 > 0)
            {
                Attack3();
            }
            if (transitionDuration2 < 0)
            {
                AttackSeq = 1;
            }
        }



    }

    private void Attack1()
    {
        AttackSeq = 2;
        animator.SetTrigger("Attack1");
        attackDuration1 = 0.4f;

        transitionDuration1 = 0.6f;

        Debug.Log("attack 1");
    }

    private void Attack2()
    {
        AttackSeq = 3;
        animator.SetTrigger("Attack2");
        attackDuration2 = 0.2f;

        transitionDuration2 = 0.4f;

        Debug.Log("attack2");

    }

    private void Attack3()
    {
        AttackSeq++;
        animator.SetTrigger("Attack3");
        Debug.Log("attack3");

    }

    private void Check()
    {

        if (attackCd > 0)
        {
            attackCd -= Time.deltaTime;
        }

        if (AttackSeq > 3)
        {
            AttackSeq = 1;
        }

    }
}
      





















