using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSciptMini3 : MonoBehaviour
{
  

    [SerializeField] private Rigidbody2D player;
    

    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        player.velocity = new Vector2(dirX * 7f, player.velocity.y);

        if (Input.GetButtonDown("Jump") == true)
        {
            player.velocity = new Vector2(player.velocity.x,14);
     
            
        }
  
    }


}
