﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Vector2 targetPos;
    private Vector2 targetPosUpwards;

    public static float playerPos_Y;
    public static float startPlayerPos_Y;
    private bool movementLR = false;

    public float speed;
    private float speedUpwards;

    private float distance;

    public float distanceLeft;
    public float distanceRight;

    private int left;
    private int right;

    private bool check_direction = true;


    public float startSpeed;
    public float MaxSpeedUpwards;

    
    public float speedMultiplier;
    public float scoreMultiplier;

    public static bool alive = true;
    
    public void Start ()
    {
       
    }
	
	
	void Update ()
    {
        
        GameSpeed();
        Movement();
    }

    void GameSpeed()
    {
        if (speedUpwards < MaxSpeedUpwards)
        {
            speedUpwards = Time.time * speedMultiplier + startSpeed;
            

        }
        else
        {
            speedUpwards = MaxSpeedUpwards;
        }
        //Debug.Log(speedUpwards);

    }
    void Movement()
    {
        playerPos_Y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        
        if (Input.GetKeyDown(KeyCode.Space) && playerPos_Y > -6)
        {

            if (check_direction == true)
            {
                left = -30;
                right = 30;
                check_direction = false;
            }
            else if (check_direction == false)
            {
                left = -60;
                right = 60;
            }

            
            if (movementLR == false)
            {
                movementLR = true;
                distance = distanceLeft;
                Rotate(left);
            }
            else if (movementLR == true)
            {
                movementLR = false;
                distance = distanceRight;
                Rotate(right);
            }

        }

        targetPos = new Vector2(transform.position.x + distance, transform.position.y);
        targetPosUpwards = new Vector2(transform.position.x, transform.position.y + 100);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, targetPosUpwards, speedUpwards * Time.deltaTime);
    }

    void Rotate (float rotation)
    {
        transform.Rotate(Vector3.forward * rotation);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Object"))
        {
            SceneManager.LoadScene("GameOver");
            alive = false;
            
        }
    }
}
