using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSciptMini3 : MonoBehaviour
{
  

    [SerializeField] private Rigidbody2D player;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private LayerMask jumpableGround;
    private Animator anim;
    private float dirX = 0;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float jumpForce = 14;
    private  enum MovementState{ idle, running, jumping, falling  }
   
    

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded() == true)
        {
            player.velocity = new Vector2(player.velocity.x,jumpForce);
     
        }

        UpdateAnimationState();

    }


    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }

        else
        {
            state = MovementState.idle;
        }

        if (player.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        else if (player.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f , Vector2.down, .1f, jumpableGround);
    }

}
