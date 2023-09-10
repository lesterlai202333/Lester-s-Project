using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public static bool isAttacking = false;
    public static AttackController instance;
    public static float timer;
  
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       
    }

    void Update()
    {

        Attack();
      
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
        {
            isAttacking = true;
            
        }
        

    }
    private void Chek()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
    }
}

