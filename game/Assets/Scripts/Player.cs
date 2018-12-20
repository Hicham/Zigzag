using System.Collections;
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

    public static int powerup1;
    public static bool powerup2 = false;
    public static bool powerup3 = false;
    public float currentTime;

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
        if (powerup2 == false && powerup3 == false)
        {
            if (speedUpwards < MaxSpeedUpwards)
            {
                speedUpwards = Time.time * speedMultiplier + startSpeed;
            }
            else
            {
                speedUpwards = MaxSpeedUpwards;
            }
            
        }
        else if (powerup2 == true && powerup3 == false)
        {
            
            speedUpwards = 1.5f;

            
            if (Time.time >= currentTime + 10f)
            {
                speedUpwards = Time.time * speedMultiplier + startSpeed;
                powerup2 = false;
            }
        }
        if (powerup2 == false && powerup3 == true)
        {
            speedUpwards = 15f;


            if (Time.time >= currentTime + 10f)
            {
                speedUpwards = Time.time * speedMultiplier + startSpeed;
                powerup2 = false;
            }
        }
        
        Debug.Log(speedUpwards);


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
        if (other.gameObject.CompareTag("powerup1"))
        {
            powerup1 += 100;
            GameObject PowerUp_obj = GameObject.FindGameObjectWithTag("powerup1");
            PowerUp_obj.SetActive(false);
        }
        if (other.gameObject.CompareTag("powerup2"))
        {
            powerup2 = true;
            powerup3 = false;
            GameObject PowerUp2_obj = GameObject.FindGameObjectWithTag("powerup2");
            PowerUp2_obj.SetActive(false);
            currentTime = Time.time;
            
            
        }
        if (other.gameObject.CompareTag("powerup3"))
        {
            powerup3 = true;
            powerup2 = false;
            GameObject PowerUp3_obj = GameObject.FindGameObjectWithTag("powerup3");
            PowerUp3_obj.SetActive(false);
            currentTime = Time.time;
        }
    }
}
