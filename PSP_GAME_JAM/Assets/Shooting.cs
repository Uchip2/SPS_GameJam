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
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    // Update is called once per frame
    void Update()
    {
        //LookMouse();
        if (canShoot == true) { Shoot(); }
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

    /*
    void LookMouse()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mouseDirection = Input.mousePosition - pos;
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position); // calculates the diraction of the mouse
        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;// calculates angle


        if (dir.y > transform.position.y)
        {
          
            
            transform.RotateAround(playertransform.transform.position, transform.forward, 2);
        }

        print(angle);



    }

    */



}
