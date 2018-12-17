using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAchievements : MonoBehaviour {

    // hij kan de public static ints niet pakken en dan

    public Text achievementText;
    public int popups = 0;
    
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
        Achievements();
        Debug.Log(Stat_totalScore);

	}

    void Achievements ()
    {
        if (Stat_totalGames == 1 && Achievement_firstGame == 0)
        {
            achievementText.text = Stat_totalScore.ToString();

            popups += 1;
        }

        if (popups < 1)
        {
            
            achievementText.text = "".ToString();
        }
        
    }

    public static void Statistic(string name, int stat)
    {
        PlayerPrefs.SetInt(name, stat);   
    }
}
