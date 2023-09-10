
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;

    private int Clicknum = 0;
    private float attackCD = 0f;

    private float attack1duration;
    private float attack2duration;
    private float attacktransition;
    private PlayerMovement move;
   
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        move = GetComponent<PlayerMovement>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Clicknum += 1;
           
        }

        Attack1();
        Timer();
        Attack2();
        
        Timer();


        Reset();

        if (playerisattacking())
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.freezeRotation = true;

        }
        


    }

    private void Attack1()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && Clicknum == 1 && attackCD <= 0 && !playerisattacking())
        {
            anim.SetTrigger("Attack1");
            attack1duration = 0.35f;
            attacktransition = 2f;
            Debug.Log(Clicknum);

        }
       
        
    }
    private void Attack2()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Clicknum == 2 && !playerisattacking() && attacktransition > 0 && attacktransition < 1.7)
        {
            anim.SetTrigger("Attack2");
            attackCD = 0.5f;
            attack2duration = 0.2f;
            Debug.Log(Clicknum + "attack 2");
        }
      
    }


 private void Timer()
    {
        
        if (attacktransition > 0)
        {
            attacktransition -= Time.deltaTime;
        }
        else if (attacktransition <= 0)
        {
            Clicknum = 0;
            attackCD = 0;
        }
    }

    private bool playerisattacking()
    {
        if (attack1duration > 0) //if the player is still attacking, the player cannot move
        {
            attack1duration -= Time.deltaTime; //timer, only when the time is up, the player regains movement.

            return true;
        }
        else if (attack2duration > 0)
        {
            attack2duration -= Time.deltaTime;
            return true;
        }
        else
        {
            return false;
        }

    }
    



    private void Reset()
    {
        if (attackCD > 0)
        {
            attackCD -= Time.deltaTime;
        }
        if (Clicknum > 2)
        {
            Clicknum = 0;
            Debug.Log("reset");
        }
    }
}

