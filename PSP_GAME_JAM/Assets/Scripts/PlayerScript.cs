using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //movement
    [Header("Movement")]
    [Range(1, 30)]
    public float speed;

    private Rigidbody2D rb; // stores the rigidbody component of the player for physics and stuff like that
    [Space()]
    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    [Space()]
    public float bulletForce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // gets the rigidbody of player and stores it in rb variable
    }


    void Update()
    {
        Movement();

        LookAtMouse();
        if (Input.GetMouseButtonDown(0)) { Shooting();  }
        
    }


    void Movement()
    {
        var move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) ; // gets input of WASD and inc by 1 or -1 if pressed 
        rb.velocity = move * speed; //multiples the 2 axis by the speed so if left is pressed (-1,0) * 4(speed) = -4,0 so it will move 4 to the left
    }



    //shooting
    void LookAtMouse() //dont know how this works .... DONT TOUCH
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    void Shooting()
    {

        GameObject bulletobj = Instantiate(bullet, firePoint.position, firePoint.rotation); //creates bullet from prefeb and stores it as game object
        Rigidbody2D bulletobjRb = bulletobj.GetComponent<Rigidbody2D>(); //gets the rigidbody of the bullet

        bulletobjRb.AddForce(bulletobj.transform.up * bulletForce, ForceMode2D.Impulse); // applies force

    }
}
