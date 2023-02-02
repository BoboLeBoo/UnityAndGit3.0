using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSciptMini3 : MonoBehaviour
{
    public float playerSpeed;
    [SerializeField]
    private Rigidbody2D rb; 
    private Vector2 movement;
    

    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("Jump");
            GetComponent<Rigidbody2D>().velocity = new Vector3(0,7,0);
        }
        movement.x = Input.GetAxisRaw("Horizontal");
  
    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

}
