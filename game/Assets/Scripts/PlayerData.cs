using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerData : MonoBehaviour
{

    public int highscore;

    public Text gameText;
    private float score;
    private float pickUpScore;

    public static int scoreRounded;
    public static string username = "gebruiker2";

    void Start()
    {
        Player.startPlayerPos_Y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        highscore = PlayerPrefs.GetInt("HighScore", 0);
    }


    void Update()
    {

        
        score = (Player.playerPos_Y - Player.startPlayerPos_Y);
        scoreRounded = (int)System.Math.Round(score);


        if (scoreRounded > highscore || highscore < 1)
        {
            gameText.text = "Score: " + scoreRounded.ToString();
        }
        else
        {
            gameText.text = "Highscore: " + highscore + Environment.NewLine + "Score: " + scoreRounded.ToString();
        }

        if (Player.alive == false)
        {
            PlayerPrefs.SetInt("HighScore", scoreRounded);
        }

    }


}
