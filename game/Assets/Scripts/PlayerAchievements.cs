using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAchievements : MonoBehaviour {

    // maak int goal_(achievement) = ???  om het makkelijker te maken om alles terug te pakken enz

    public Text achievementText;
    private int completeCount = 0;

    public List<float> FrozenTime = new List<float>();
    public List<string> CompletedAchievements = new List<string>();

    private bool check = true;

    //PLAYER ACHIEVEMENTS
    public static string start = "Achievement: ";

    public static string text_firstGame = "Play your first game";
    public static string firstGame = "FirstGame";
    public static int Achievement_firstGame;
    public static int goal;

    public static string text_first25Games = "Play 25 games";
    public static string first25Games = "25Games";
    public static int Achievement_first25Games;

    public static string text_first100Games = "Play 100 games";
    public static string first100Games = "100Games";
    public static int Achievement_first100Games;

    public static string text_score1000 = "Achieve over 1000+ totalscore";
    public static string score1000 = "Score1000";
    public static int Achievement_score1000;


    // PLAYER STATS
    public static string totalGames = "TotalGames";
    public static int Stat_totalGames;

    public static string totalScore = "TotalScore";
    public static int Stat_totalScore;

    public static string PowerupPickups = "PowerupPickups";
    public static int Stat_PowerupPickups;



    //public static string firstGame = "FirstGame";
    //public static int Achievement_firstGame;

    //public static string first25Games = "25Games";
    //public static int Achievement_first25Games;

    //// PLAYER STATS
    //public static string totalGames = "TotalGames";
    //public static int Stat_totalGames;

    //public static string totalScore = "TotalScore";
    //public static int Stat_totalScore;

    //public static string PowerupPickups = "PowerupPickups";
    //public static int Stat_PowerupPickups;



    void Awake()
    {

    }
     
    void Start () {
        //// PLAYER ACHIEVEMENTS
        Achievement_firstGame = PlayerPrefs.GetInt(firstGame, 0);
        Achievement_first25Games = PlayerPrefs.GetInt(first25Games, 0);
        Achievement_first100Games = PlayerPrefs.GetInt(first100Games, 0);
        Achievement_score1000 = PlayerPrefs.GetInt(score1000, 0);


        // PLAYER STATS
        Stat_totalGames = PlayerPrefs.GetInt(totalGames, 0);
        Stat_totalScore = PlayerPrefs.GetInt(totalScore, 0);
        Stat_PowerupPickups = PlayerPrefs.GetInt(PowerupPickups, 0);

    }
	
	
	void Update () {

        AddAchievements();

        if (!Player.alive /* && check == true*/)
        {
            Achievements();
            check = false;
        }
 
	}

    void AddAchievements()
    {
        if (Achievement_firstGame == 1)
        {
            CompletedAchievements.Add(firstGame);
        }
        if (Achievement_first25Games == 1)
        {
            CompletedAchievements.Add(first25Games);
        }
        if (Achievement_first100Games == 1)
        {
            CompletedAchievements.Add(first100Games);
        }
        if (Achievement_score1000 == 1)
        {
            CompletedAchievements.Add(score1000);
        }
    }

    void Achievements ()
    {
        if (Stat_totalGames == 1 && Achievement_firstGame == 0)
        {
            string sendText = start + text_firstGame.ToString();
            CompleteAchievement(firstGame, sendText);
        }

        if (Stat_totalGames == 25 && Achievement_first25Games == 0)
        {

            string sendText = start + text_first25Games.ToString();
            CompleteAchievement(first25Games, sendText);
        }

        if (Stat_totalGames == 100 && Achievement_first100Games == 0)
        {
            string sendText = start + text_first100Games.ToString();
            CompleteAchievement(first100Games, sendText);
        }


        if (Stat_totalScore > 1000 && Achievement_score1000 == 0)
        {
            string sendText = start + text_score1000.ToString();
            CompleteAchievement(score1000, sendText);
        }
    }

   

    public void CompleteAchievement(string name, string aText)
    {
        PlayerPrefs.SetInt(name, 1);

        if (completeCount > 1)
        {
            achievementText.text = aText + Environment.NewLine + " And you've unlocked " + completeCount + " more".ToString();
        }
        else
        {
            achievementText.text = aText;
        }

        if (FrozenTime.Count < 1)
        {
            float fTime = Time.time + 3f;
            FrozenTime.Add(fTime);
            completeCount += 1;
        }
        if (FrozenTime[0] < Time.time)
        {
            achievementText.text = "".ToString();
        }



    }

  

    public static void Statistic(string name, int stat)
    {
        PlayerPrefs.SetInt(name, stat);   
    }
}
