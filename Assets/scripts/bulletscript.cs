using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "enemy")
        {   
            scoreManager.instance.addPoint();
            other.gameObject.GetComponent<enemyscript>().death();
            Destroy(gameObject);
        }
    }
}
