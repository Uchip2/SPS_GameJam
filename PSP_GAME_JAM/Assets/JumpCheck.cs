using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{
    
    public bool isgrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Untagged"))
        {
            isgrounded = true;
        }
    }





    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Untagged"))
        {
            isgrounded = false ;
        }
    }


}
