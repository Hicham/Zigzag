using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerData : MonoBehaviour {

    public int highscore;
    

    public Text gameText;
    private float score;

    private float pickUpScore;

    private float playerPos_Y;
    private float startPlayerPos_Y;

    void Start ()
    {
        startPlayerPos_Y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        highscore = PlayerPrefs.GetInt("HighScore", 0);
	}
	

	void Update ()
    {
        playerPos_Y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        score = (playerPos_Y - startPlayerPos_Y);
        int round = (int)System.Math.Round(score);
        gameText.text = "Score: " + round.ToString();

        Debug.Log(highscore);
        if (round > highscore)
        {
            PlayerPrefs.SetInt("HighScore", round);
            
        }

	}


}
