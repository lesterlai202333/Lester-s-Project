using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private CapsuleCollider2D coll; // Changed to CapsuleCollider2D
    [SerializeField] private LayerMask groundLayer;

    private float directionX = 0f;

    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpForce = 14f;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<CapsuleCollider2D>(); // Changed to CapsuleCollider2D
    }

    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");

        float slopeFactor = 1f; // Initialize the slopeFactor to 1

        if (IsGrounded())
        {
            float slopeAngle = GetSlopeAngle();
            slopeFactor = Mathf.Cos(slopeAngle * Mathf.Deg2Rad);
        }
        rb.velocity = new Vector2(directionX * speed * slopeFactor, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();

        
    }



  
    
    

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.CapsuleCast(coll.bounds.center, coll.bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, .1f, groundLayer); // Changed to CapsuleCast
        return raycastHit.collider != null;
    }

    private float GetSlopeAngle()
    {
        RaycastHit2D raycastHit = Physics2D.CapsuleCast(coll.bounds.center, coll.bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, .1f, groundLayer); // Changed to CapsuleCast
        if (raycastHit.collider != null)
        {
            return Vector2.Angle(Vector2.up, raycastHit.normal);
        }
        return 0f;
    }

    private void UpdateAnimationState()
    {
        if(directionX>0)
        {
            sprite.flipX = false;
        }
        else if (directionX<0)
        { sprite.flipX = true;
        }
        MovementState state;
        if (directionX > 0f && IsGrounded())
        {
            state = MovementState.running;
            
        }
        else if (directionX < 0f && IsGrounded())
        {
            state = MovementState.running;
            
        }
        else if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
        else
        {
            state = MovementState.idle;
        }

        anim.SetInteger("state", (int)state);
    }

    private enum MovementState { idle, running, jumping, falling }

    

}
