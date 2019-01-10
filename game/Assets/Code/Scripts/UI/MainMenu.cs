using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene("Test");
    }

    public void Achievements()
    {
        SceneManager.LoadScene("Achievements");
    }

    public void Leaderboards()
    {
        SceneManager.LoadScene("Leaderboards");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
}
