using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Camera cam;
    private Rigidbody2D rb;
    Vector2 mousepos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        LookMouse();   
    }


    void LookMouse()
    {

        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

        //calculates the position and angle
        Vector2 lookDirection = mousepos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90f;

        //rotates the player
        rb.rotation = angle;
        
    }
}
