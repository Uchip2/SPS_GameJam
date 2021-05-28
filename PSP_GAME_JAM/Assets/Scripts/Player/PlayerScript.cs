using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour
{
    

    private Rigidbody2D rb; // stores the rigidbody component of the player for physics and stuff like that
    //movement
    [Header("Movement")]
    [Range(1, 30)]
    public float speed;
   
    public enum timelines { Future, Medival } 
    public timelines currentTime;








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
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")); // gets input of WASD and inc by 1 or -1 if pressed 
        rb.velocity = input * speed; //multiples the 2 axis by the speed so if left is pressed (-1,0) * 4(speed) = -4,0 so it will move 4 to the left
    }






}

