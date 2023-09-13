using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim; //declaring the variables, as in Csharp, variables have to be declared first.
    private CapsuleCollider2D coll; // Box collider changed to CapsuleCollider2D 
    [SerializeField] private LayerMask groundLayer; //this allows the system to access and interact with another layer
    public GameObject GameOverCanvas;

    private float directionX = 0f; //setting up varaibles

    [SerializeField] private float speed = 7f;
    [SerializeField] public static float jumpForce = 14f;//setting up variables, the serializefield allows me to access it in the unity page to test out the optimum values
    public static bool isjumping;
 




    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<CapsuleCollider2D>(); // these code allow visual studio to access the information inside the components that this script is attached to.
    }
  
    private void Update()
    {
       
        directionX = Input.GetAxisRaw("Horizontal"); //Unity has its player movement system half setup, I am accessing the horizontal axis movement here.

        float slopeFactor = 1f; // Initialize the slopeFactor to 1, as this is the max value of a cosine function, and the max speed factor of the player.

        if (IsGrounded())
        {
            float slopeAngle = GetSlopeAngle(); //sets the slopeangle variable to the value got from the GetSlopeAngle method.
            slopeFactor = Mathf.Cos(slopeAngle * Mathf.Deg2Rad); //converts it to a ratio
        }

      
        
            rb.velocity = new Vector2(directionX * speed * slopeFactor, rb.velocity.y);
        

        
        
        //so if the player is grounded, it calculates the slopeangle with the previous method, then the slope angle is changed to that value, and is converted to degrees which is usable, the slope factor makes the thing a ratio which is used in the rb.velocity. This makes the player move at different rates when it runs over bumps.


        if (Input.GetButtonDown("Jump") && IsGrounded()) //checks that space is pressed, and that the player is grounded.
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //sets the velocity of the player to the x velocity that the player already has, and a constant(jumpforce)
            
        }
        


        Check(); //constantly calls the stuff in the method(newly added method)



        UpdateAnimationState(); //constantly calls the stuff in the method (UpdateAnimationState)


    }







    //the private bool / private void / private float are ways to store data / code inside a variable. float is a number, bool is either true or false, void is a way of storing code inside a method.
    private bool IsGrounded() //this is a way to check wheter the player is grounded, it casts a ray .1f below the player(vector 2.down) from the center of the collider to check for the ground layer
    {
        RaycastHit2D raycastHit = Physics2D.CapsuleCast(coll.bounds.center, coll.bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, .1f, groundLayer); // Changed to CapsuleCast
        return raycastHit.collider != null; //if the code above is true which it did detect something, then the return value from it wouldn't be equal to null, which it is true
    }

    private float GetSlopeAngle()//used to calculate the angle of slope beneath the player character
    {//so it casts a capsule shaped ray from the center of the capsule collider down, the distance is .1f to detect the layer under it, if there is a layer, it would calculate the angle, if no, the angle is 0. The value of this angle is stored in this method
        RaycastHit2D raycastHit = Physics2D.CapsuleCast(coll.bounds.center, coll.bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, .1f, groundLayer); // Changed to CapsuleCast
        if (raycastHit.collider != null)
        {
            return Vector2.Angle(Vector2.up, raycastHit.normal); //value returned
        }
        return 0f; //if there are no detection from the raycast, the value is set to 0
    }


    private void Check() //this method checks for whether an attack animation is played, if it is true, the player's x velocity is set to 0, so it cannot move left/right 
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 1") && !isjumping)
        {

            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.freezeRotation = true;
        }
       
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 2") && !isjumping)
        {

            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.freezeRotation = true;
        }
      
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 3") && !isjumping)
        {

            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.freezeRotation = true;
        }

        if (HealthManager.playerHealth <= 0) //if player health drops below 0, the player dies, and the scene restarts
        {

            die();

        }

    }
    void die() //death method
    {
        anim.Play("HeroKnight_Death");
        rb.bodyType = RigidbodyType2D.Static;
    }

 


    private void Gameover() //after the player dies, the scene is reset
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateAnimationState()//this section controls the player movement animation transitions. 
    {
        if (!AttackController.isAttacking) //newly added condition, if the player is attacking, it cannot turn around, this was added to solve the issue that if the player turns around quick during an attack animation, there will be 2 areas where the player can deal damage
        {
            if (directionX > 0) //if the player moves right（positve）, the sprite wouldn't flip x（turn around）
            {
                sprite.flipX = false;
            }
            else if (directionX < 0) //if the player moves left（backwards, negative）, the sprite turns around（flip x）
            {
                sprite.flipX = true;
            }
        }

        MovementState state; //it declares the movementstate enum to just state as a variable, the point is that the value isn't defined, so that I can write code that sets its value
       
            if (directionX > 0f && IsGrounded()) //if the player moves right/left and it is grounded, the player performs a running animation
            {
                state = MovementState.running;
                isjumping = false;
            }
            else if (directionX < 0f && IsGrounded())
            {
                state = MovementState.running;
                isjumping = false;
            }
            else if (rb.velocity.y > 0.1f) //if the y velocity of the player >0.1, the player performs a jumping animation, or else it performs a falling. .1 is used instead of 0 is because the animations for falling/jumping might be triggered when the player moves slightly upwards
            {
                state = MovementState.jumping;
                isjumping = true;
            }
            else if (rb.velocity.y < -0.1f)
            {
                state = MovementState.falling;
                isjumping = true;
            }
            else //otherwise the player persforms the idle animation
            {
                state = MovementState.idle;
            }

            anim.SetInteger("state", (int)state); //it sets the integer value of a parameter in the animator
        
    }

    private enum MovementState { idle, running, jumping, falling }//enums are used to represent a fixed set of named constants with specific meaning

    


}