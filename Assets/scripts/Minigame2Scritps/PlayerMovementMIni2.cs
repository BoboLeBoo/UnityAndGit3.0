using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovementMIni2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump_height;

    private Rigidbody2D body;
    private Animator anim;
    

    private void Awake()
    {
        // Grab references from game objects
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip player when moving in different directions
        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(Input.GetKey(KeyCode.Space)) 
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }

        // Set animator parameters
        anim.SetBool("Run", horizontalInput != 0);
    }
}
