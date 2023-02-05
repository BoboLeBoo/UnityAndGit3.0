using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovementSciptMini3 : MonoBehaviour
{
  

    [SerializeField] private Rigidbody2D player;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private GameObject blood;
    [SerializeField] private LayerMask jumpableGround;
    private Animator anim;
    private float dirX = 0;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float jumpForce = 14;
    private  enum MovementState{ idle, running, jumping, falling  }
    [SerializeField] private AudioSource JumpSound;
    [SerializeField] private AudioSource DeathSound;
    [SerializeField] private AudioSource FinishSound;
    [SerializeField] private Text DeathTxt;
    private int deaths = 0;
   
    

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        deaths = PlayerPrefs.GetInt("deaths");
        DeathTxt.text = "Deaths: " + deaths.ToString();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        

        player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded() == true)
        {
            JumpSound.Play();
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {   
            Instantiate(blood , transform.position, Quaternion.identity);
            DeathSound.Play();
            deaths += 1;
            PlayerPrefs.SetInt("deaths", deaths);
            player.bodyType = RigidbodyType2D.Static;
            sprite.enabled = false;
            Invoke("RestartLevel", 2);
            
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag == "finish")
       {
            FinishSound.Play();
            PlayerPrefs.SetInt("deaths", 0);
            Invoke("LoadEndScene", 2);
       }
    }

    private void LoadEndScene()
    {
        SceneManager.LoadScene(4,LoadSceneMode.Single);
    }

}
