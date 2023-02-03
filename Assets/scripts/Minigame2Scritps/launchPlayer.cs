using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchPlayer : MonoBehaviour
{

    [SerializeField] private float launcherPower = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * launcherPower, ForceMode2D.Impulse);
    }
}
