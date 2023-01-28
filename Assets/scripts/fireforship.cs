using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireforship : MonoBehaviour
{

    
    [SerializeField]
    
    private GameObject projectile; 
   
    

    public void Update()
    {
        Vector3 location = transform.position;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(projectile, location, Quaternion.identity);
        }
    }
}
