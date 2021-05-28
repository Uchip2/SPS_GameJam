using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [Header("Gameobjects references")]
    public GameObject bullet;
    public Transform firePoint;

    [Header("Timer")]
    [Range(1, 10)]
    public float waitingTime = 2;
    [Header("shooting")]
    [Range(1, 30)]
    public float bulletForce;
    public GameObject playertransform;

    private Rigidbody2D rb;
    private bool canShoot = true;

    [Header("time line check")]
    public PlayerScript player;
    public PlayerScript.timelines WeaponTimeline;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if(player.currentTime == WeaponTimeline)
        {
            if (canShoot == true) { Shoot(); }
        }
        
        
    }

    void Shoot()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullets = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            
            Rigidbody2D rb = bullets.GetComponent<Rigidbody2D>();

            rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);


            canShoot = false;
            StartCoroutine("WaitingShootingTime"); // calls the watitingshooting time and starts countdown
        }
    }


    IEnumerator WaitingShootingTime()
    {
        yield return new WaitForSeconds(waitingTime);
        canShoot = true;
    } // waits certain seconds

    


    



}
