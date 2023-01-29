using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMIni2 : MonoBehaviour
{

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

}
