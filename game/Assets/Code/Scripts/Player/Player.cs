using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool angle = true;
    public static bool passedstartpoint = false;
    private bool randomstart = false;
    public GameObject PlayerObject;
    public float time;

    public static float playerPos_Y;
    public static float startPlayerPos_Y;

    public Vector2 speed;
    public float speedUpwards;

    public float startSpeed;
    public float MaxSpeedUpwards;


    public float speedMultiplier;
    public float scoreMultiplier;

    public static bool alive = true;

    public static int powerup1;
    public static bool powerup2 = false;
    public static bool powerup3 = false;
    private float currentTime;

    public void Start()
    {
        randomstart = false;
        alive = true;
        passedstartpoint = false;
        if (alive)
        {
            speedUpwards = startSpeed;
        }
    }

    void Update()
    {
        time = Time.timeSinceLevelLoad;
        PowerUps();
        Movement();
    }

    void PowerUps()
    {
        if (powerup2 == false && powerup3 == false)
        {
            if (speedUpwards < MaxSpeedUpwards)
            {
                
            }
            else
            {
                speedUpwards = MaxSpeedUpwards;
            }

        }
        else if (powerup2 == true && powerup3 == false)
        {

            speedUpwards = 1.5f;


            if (time >= currentTime + 10f)
            {
                speedUpwards = Time.time * speedMultiplier + startSpeed;
                powerup2 = false;
            }
        }
        if (powerup2 == false && powerup3 == true)
        {
            speedUpwards = 15f;


            if (time >= currentTime + 10f)
            {
                speedUpwards = Time.time * speedMultiplier + startSpeed;
                powerup2 = false;
            }
        }
    }

    void Movement()
    {
        //Beweegt de camera pas vanaf punt X
        playerPos_Y = GameObject.FindGameObjectWithTag("Player").transform.position.y;

        //SpeedUpwards zorgt voor een berekening om sneller te gaan de langer het spel bezig is.
        if (speedUpwards < MaxSpeedUpwards)
        {
            speedUpwards = time * speedMultiplier + startSpeed;
        }
        else
        {
            speedUpwards = MaxSpeedUpwards;
        }

        //Vector2.up zorgt dat de player altijd naar boven zal bewegen in vergelijking met de rotatie van het object. Dit is dus de motor.
        speed = Vector2.up * speedUpwards;
        transform.Translate(speed);
        
        //Checken of hij voorbij het startpunt is gegaan en geeft een random kant als startdirection
        if (transform.position.y > -6 && randomstart == false)
        {
            passedstartpoint = true;
            int startrand = Random.Range(0,1);
            if (startrand == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 45f);
                angle = false;
                randomstart = true;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 315f);
                angle = true;
                randomstart = true;
            }
        }

        //Toggle van direction
        if (Input.GetKeyDown(KeyCode.Space) && passedstartpoint == true)
        {
            if (angle)
            {
                transform.rotation = Quaternion.Euler(0, 0, 45f);
                angle = false;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 315f);
                angle = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Object"))
        {
            alive = false;
            speedUpwards = 0;
            SceneManager.LoadScene("GameOver");
        }

        if (other.gameObject.CompareTag("powerup1"))
        {

            powerup1 += 100;
            GameObject PowerUp_obj = GameObject.FindGameObjectWithTag("powerup1");
            PowerUp_obj.SetActive(false);

            PlayerData.totalPickups += 1;
        }

        if (other.gameObject.CompareTag("powerup2"))
        {
            powerup2 = true;
            GameObject PowerUp2_obj = GameObject.FindGameObjectWithTag("powerup2");
            PowerUp2_obj.SetActive(false);
            currentTime = time;

            PlayerData.totalPickups += 1;

        }
        if (other.gameObject.CompareTag("powerup3"))
        {
            powerup3 = true;
            powerup2 = false;
            GameObject PowerUp3_obj = GameObject.FindGameObjectWithTag("powerup3");
            PowerUp3_obj.SetActive(false);
            currentTime = time;
        }

    }


}
