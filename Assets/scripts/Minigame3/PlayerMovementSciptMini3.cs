using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSciptMini3 : MonoBehaviour
{
  

    [SerializeField] private Rigidbody2D player;
    private Animator anim;
    private float dirX = 0;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float jumpForce = 14;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);

        if (Input.GetButtonDown("Jump") == true)
        {
            player.velocity = new Vector2(player.velocity.x,jumpForce);
     
        }

        UpdateAnimationState();

    }


    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }

        else
        {
            anim.SetBool("running", false);
        }
    }
}
