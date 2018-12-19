using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAchievements : MonoBehaviour {

    // hij kan de public static ints niet pakken en dan

    public Text achievementText;
    private int completeCount = 0;

    public List<float> FrozenTime = new List<float>();
    public List<string> CompletedAchievements = new List<string>();

    //PLAYER ACHIEVEMENTS

    public static string firstGame = "FirstGame";
    public static int Achievement_firstGame;

    public static string first25Games = "25Games";
    public static int Achievement_first25Games;

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


        // PLAYER STATS
        Stat_totalGames = PlayerPrefs.GetInt(totalGames, 0);
        Stat_totalScore = PlayerPrefs.GetInt(totalScore, 0);
        Stat_PowerupPickups = PlayerPrefs.GetInt(PowerupPickups, 0);

    }
	
	
	void Update () {

        if (!Player.alive)
        {
            Achievements();
            
        }
        
	}

    void Achievements ()
    {

        if (Stat_totalGames == 1 && Achievement_firstGame == 0)
        {
            string sendText = "Achievement: Play your first game".ToString();
            CompleteAchievement(firstGame, sendText);
        }

        if (Stat_totalGames == 25 && Achievement_first25Games == 0)
        {

            string sendText = "Achievement: Play 25 Games".ToString();
            CompleteAchievement(first25Games, sendText);


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
