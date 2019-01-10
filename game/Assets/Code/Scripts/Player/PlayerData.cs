using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerData : MonoBehaviour
{

    public int highscore;
    public int lastScore;

    public TextMeshProUGUI LastScoreText;
    public TextMeshProUGUI HighScoreText;
    private float score;
    private float pickUpScore;

    public static int scoreRounded;
    public static string username = "gebruiker2";

    public static int totalPickups;

    void Start()
    {
        Player.startPlayerPos_Y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        highscore = PlayerPrefs.GetInt("HighScore", 0);
    }


    void Update()
    {
        Vector2 offset = new Vector2(0, Player.playerPos_Y);
        if (Player.passedstartpoint)
        {
            score = (offset.y + Player.playerPos_Y - Player.startPlayerPos_Y + Player.powerup1);
        }
        scoreRounded = (int)System.Math.Round(score);

        if (scoreRounded > highscore || highscore < 1)
        {
            HighScoreText.text = "Score: " + scoreRounded.ToString();
        }
        else
        {
            HighScoreText.text = "Highscore: " + highscore + Environment.NewLine + "Score: " + scoreRounded.ToString();
        }

        if (Player.alive == false)
        {
            PlayerPrefs.SetInt("LastScore", scoreRounded);
            PlayerPrefs.SetInt("HighScore", scoreRounded);

            PlayerAchievements.Statistic(PlayerAchievements.totalGames, PlayerAchievements.Stat_totalGames + 1);
            PlayerAchievements.Statistic(PlayerAchievements.totalScore, PlayerAchievements.Stat_totalScore + scoreRounded);
            PlayerAchievements.Statistic(PlayerAchievements.PowerupPickups, PlayerAchievements.Stat_PowerupPickups + totalPickups);
        }

    }


}
