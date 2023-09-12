using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class AttackController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public static bool isAttacking = false; //static so that this variable can be accessed outside of this script.
    public static AttackController instance;
    public static float cooldowntimer = 0;


    // Start is called before the first frame update
    private void Awake() //Awake is called when the script object is initialised, regardless of whether or not the script is enabled. 
    {
        instance = this; //Store a reference to the current version of this script in the instance variable
    }

    private void Start() //while Start is called on the frame when a script is enabled, so before any update methods are called
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); //getting the info from the components of the object that this attacktroller script is attached to.

    }
    void Update() //constantly calls the attack method
    {

        Attack();
        
        


    }
    void Attack() //if the player left clicks and that isattacking bool is false, the isattacking bool is set to true.
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking && cooldowntimer <= 0 && !GameOver.dead)
        {
            isAttacking = true;

        }
    }

   
}

// && GameOver.dead == false

