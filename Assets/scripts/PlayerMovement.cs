using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed = 5f;
    Vector2 movement;
    public Rigidbody2D rb;
    private int sceneBuildIdx = 0;


    // Update is called once per frame

    void Start()
    {
        
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyUp(KeyCode.L))
        {
            SceneManager.LoadScene(sceneBuildIdx, LoadSceneMode.Single);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "enemy")
        {   
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            scoreManager.instance.removeMoney();
            //Destroy(gameObject);
        }
    }
        
}
