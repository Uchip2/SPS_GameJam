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
    private bool facingRight;
    [Header("Jump")]
    [Range(1, 50)]
    public float jumpForce;
    private JumpCheck jumpCheck;

   





    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // gets the rigidbody of player and stores it in rb variable
        jumpCheck = GetComponentInChildren<JumpCheck>();
    }


    void Update()
    {
        Movement();
        if (Input.GetKey("space") || Input.GetKey("up") || Input.GetKey("w") && jumpCheck.isgrounded == true) { Jump(); }
    }


    void Movement()
    {
        var input = Input.GetAxisRaw("Horizontal"); // gets input of WASD and inc by 1 or -1 if pressed 
        rb.velocity = new Vector2(input * speed, rb.velocity.y); //multiples the 2 axis by the speed so if left is pressed (-1,0) * 4(speed) = -4,0 so it will move 4 to the left


        //checks if the character is fliped
        if (input > 0 && facingRight == false)
        {
            Flip();
        }
        else if (input < 0 && facingRight == true)
        {
            Flip();
        }
    }


    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); //flips character
        facingRight = !facingRight;
    } //rotates charachter around

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }



}

