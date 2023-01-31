using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBackground : MonoBehaviour
{
    Material backgroundMaterial;

    Vector2 backgroundShift;
    public Vector2 backgroundMovingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        backgroundMaterial.mainTextureOffset = backgroundShift;
        backgroundShift += backgroundMovingSpeed * Time.deltaTime;
    }
}
