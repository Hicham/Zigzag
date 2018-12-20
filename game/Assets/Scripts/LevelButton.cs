using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }

    public void Endless()
    {
        SceneManager.LoadScene("Endless");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Back1()
    {
        SceneManager.LoadScene("Play");
    }
}
