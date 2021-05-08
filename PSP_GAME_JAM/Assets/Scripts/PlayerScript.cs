using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //movement
    [Range(1, 30)]
    public float speed;

    private Rigidbody2D rb; // stores the rigidbody component of the player for physics and stuff like that


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // gets the rigidbody of player and stores it in rb variable
    }


    void Update()
    {
        Movement(); 
    }


    void Movement()
    {
        var move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) ; // gets input of WASD and inc by 1 or -1 if pressed 
        rb.velocity = move * speed; //multiples the 2 axis by the speed so if left is pressed (-1,0) * 4(speed) = -4,0 so it will move 4 to the left
    }
}
