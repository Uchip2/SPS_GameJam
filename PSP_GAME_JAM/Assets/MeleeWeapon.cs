using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [Header("assigment variables")]
    Rigidbody2D rb;
    public GameObject meeleAttackHitBox;
     
    [Header("time line check")]
    public PlayerScript player;
    public PlayerScript.timelines WeaponTimeline;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerScript>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.currentTime == WeaponTimeline) { 
            
            if (Input.GetMouseButton(0)) { meeleAttackHitBox.SetActive(true);  } else { meeleAttackHitBox.SetActive(false); } 
        
        
        }
    }

    


}
