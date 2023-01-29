using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{

    public GameObject blood;
public void death()

{
    Instantiate(blood , transform.position, Quaternion.identity);
    Destroy(gameObject);
}
}
