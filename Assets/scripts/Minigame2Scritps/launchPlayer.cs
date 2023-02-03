using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchPlayer : MonoBehaviour
{

    [SerializeField] private float launcherPower = 20f;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("activated", true);
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * launcherPower, ForceMode2D.Impulse);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("activated", false);
    }
}
