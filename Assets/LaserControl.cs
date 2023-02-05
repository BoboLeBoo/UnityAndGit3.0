using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    [SerializeField]
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;

    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        DisableLaser();
    }
    // Update is called once per frame

    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            EnableLaser();
        }
        if(Input.GetButton("Fire1"))
        {
            UpdateLaser();
        }
        if(Input.GetButtonUp("Fire1"))
        {
            DisableLaser();
        }
        RotateToMouse();
    }
    private void EnableLaser() 
    {
        lineRenderer.enabled = true;
    }

    private void UpdateLaser()
    {
        Vector2 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, mousePos);

        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)firePoint.transform.position, direction.normalized, direction.magnitude);

        if(hit)
        {
            lineRenderer.SetPosition(1, hit.point);
            GameObject asteroid = hit.collider.GameObject();
            if(asteroid.tag == "platform")
            {
                Destroy(asteroid);
            }
        }
    }

    private void DisableLaser()
    {
        lineRenderer.enabled = false;
    }

    private void RotateToMouse()
    {
        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - firePoint.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0,0,angle);
        transform.rotation = rotation;
    }
}
