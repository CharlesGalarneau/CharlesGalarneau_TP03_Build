﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    public float speed = 1.5f;
    public float jumpHeight = 1f;  

    // Private vars
    float groundDistance = 0.25f;
    LayerMask groundLayerMask = 1;
    Vector3 moveDirection;
    Rigidbody rb;
    bool isGrounded;
    Animator PaladinAnimation;
    public Transform cubeCamera;
    float runningSpeed =5f;
    float WalkingSpeed = 2.5f;
    float boostValue = 0;
    public PlayerStat playerStat;
    public float Stamina;
    public float StaminaCost =2.5f;
    public bool Isrunning;

    float vertical, horizontal;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PaladinAnimation = GetComponent<Animator>();
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
        playerStat = FindObjectOfType<PlayerStat>();
        Stamina = playerStat.Stamina;
        WalkingSpeed = playerStat.WalkingSpeed;



        // 1.2 Inputs
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        // Déplacements
        moveDirection = cubeCamera.forward * vertical;
        moveDirection += cubeCamera.right * horizontal;

        // animations des mouvements pour le personage pricipale
        PaladinAnimation.SetFloat("Horizontal", horizontal);
        PaladinAnimation.SetFloat("Vertical", vertical);
        // Respawn ------------------------------------------------
        if (transform.position.y < -15f)
            transform.position = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftShift) && Stamina >0)
        {
            playerStat.StaminaCost(); 
           
            Debug.Log(Stamina);
            Isrunning = true;
            speed = WalkingSpeed *2;
            PaladinAnimation.SetFloat("Horizontal", horizontal);
            PaladinAnimation.SetFloat("Vertical", vertical);

        }
        else
            
        
          
        
        speed = WalkingSpeed;
        PaladinAnimation.SetFloat("Horizontal", horizontal);
        PaladinAnimation.SetFloat("Vertical", vertical);
    }



    private void FixedUpdate()
    {        
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }
    
}

