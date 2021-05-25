using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [Header("assigment variables")]
    Rigidbody2D rb;

    [Header("Meele attack")]
    public Transform firepoint;
    public float range = 3;
    
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
        if(player.currentTime == WeaponTimeline) { if (Input.GetMouseButton(0)) { Attack(); Debug.Log("Meele");  }  }
    }

    void Attack()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, firepoint.up, range);

        if (ray.collider.CompareTag("Enemy"))
        {
            GameObject enemy = ray.collider.gameObject;
            Destroy(enemy);
        }
    }


}
