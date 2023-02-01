using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovementMIni2 : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jump_height;
    [SerializeField] public BoxCollider2D TeleborderL;
    [SerializeField] public BoxCollider2D TeleborderR;

    private bool grounded;
    private string lastTeleport = "";

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
        body.velocity = new Vector2(horizontalInput * movementSpeed, body.velocity.y);

        // Flip player when moving in different directions
        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(Input.GetKey(KeyCode.Space) && grounded) 
        {
            Jump();
        }

        // Set animator parameters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void FixedUpdate() //move physics related stuff to this funkction
    {
        
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump_height);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            lastTeleport = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // this teleports the player to the other side of the screen, when he leaves on one side
        // add changed direction method, so that u can pass by changing direction of the player
        if (collision.gameObject.name == TeleborderL.name && collision.gameObject.name != lastTeleport || collision.gameObject.name == "")
        {
            body.position = new Vector3(TeleborderR.transform.position.x, TeleborderR.transform.position.y, movementSpeed);
            lastTeleport = TeleborderR.name;
        }
        if (collision.gameObject.name == TeleborderR.name && collision.gameObject.name != lastTeleport || collision.gameObject.name == "")
        {
            body.position = new Vector3(TeleborderL.transform.position.x, TeleborderL.transform.position.y, movementSpeed);
            lastTeleport = TeleborderL.name;
        }
    }
}
