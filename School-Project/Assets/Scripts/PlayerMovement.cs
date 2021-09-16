using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    //movmement
    public Rigidbody2D rb;
    public float speed = 500f;
    Vector2 movement;

    //gun movement
    private Transform aimTransform;
    private Transform aimTransform2;
    public GameObject Gun;
    public GameObject SecondGun;
    public float angle;

    private bool LeftAngle;
    private bool RightAngle;

    //bullet
    public float bulletForce = 20f;
    public Transform firePoint;
    public GameObject bulletPrefab;

    //PlayerMovement

    public Animator PlayerAnimation;
    private bool isRunning = false;
    private bool isRunningLeft;
    private bool isRunningRight;


    public ParticleSystem dust;

    private void Awake()
    {
        SecondGun.SetActive(false);
        aimTransform = transform.Find("Gun");
        aimTransform2 = transform.Find("SecondGun");
    }

    void Update()
    {
       

        if (angle >= 90 || angle <= -90)
        {
            LeftAngle = true;
        }
        else
        {
            LeftAngle = false;
        }

        if (angle <= 90 || angle >= -90)
        {
            RightAngle = true;
        }
        else
        {
            RightAngle = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            isRunning = true;
            CreateDust();
        }
        else
        {
            isRunning = false;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        HandleAiming();
        HandleShooting();

        if (LeftAngle == true)
        {
            SecondGun.SetActive(true);
            Gun.SetActive(false);

        }

        else if (RightAngle == true)
        {
            SecondGun.SetActive(false);
            Gun.SetActive(true);

        }

        if (isRunning == true)
        {

            if (LeftAngle == true)
            {
                PlayerAnimation.SetBool("PlayerWalkLeft", true);
                PlayerAnimation.SetBool("PlayerWalkRight", false);
                PlayerAnimation.SetBool("PlayerLeft", false);
                PlayerAnimation.SetBool("PlayerRight", false);
            }
            else
            {
                PlayerAnimation.SetBool("PlayerWalkRight", true);
                PlayerAnimation.SetBool("PlayerWalkLeft", false);
                PlayerAnimation.SetBool("PlayerLeft", false);
                PlayerAnimation.SetBool("PlayerRight", false);
            }
            
        }
        if (isRunning == false)
        {
            if (LeftAngle)
            {
                PlayerAnimation.SetBool("PlayerLeft", true);
                PlayerAnimation.SetBool("PlayerRight", false);
                PlayerAnimation.SetBool("PlayerWalkRight", false);
                PlayerAnimation.SetBool("PlayerWalkLeft", false);
            }
            else
            {
                PlayerAnimation.SetBool("PlayerLeft", false);
                PlayerAnimation.SetBool("PlayerRight", true);
                PlayerAnimation.SetBool("PlayerWalkRight", false);
                PlayerAnimation.SetBool("PlayerWalkLeft", false);
            }
        }



    }
    private void FixedUpdate()
    {
        movement.Normalize();
        rb.velocity = new Vector2(movement.x * speed * Time.fixedDeltaTime, movement.y * speed * Time.fixedDeltaTime);
    }
    private void HandleAiming()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 gunPos = Camera.main.WorldToScreenPoint(aimTransform.transform.position);
        mousePos.x = mousePos.x - gunPos.x;
        mousePos.y = mousePos.y - gunPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        aimTransform.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        aimTransform2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        CameraShake.Instance.ShakeCamera(0.5f, .1f);
    }

    void CreateDust()
    {
        dust.Play();
    }
}