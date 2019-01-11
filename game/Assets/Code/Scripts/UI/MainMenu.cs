using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public bool check = true;
    public GameObject on, off;
    public Button Mute;

    public void Start()
    {
        Mute.onClick.AddListener(OnChangeValue);
    }

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

    public void OnChangeValue()
    {
        if (check)
        {
            check = true;
            on.SetActive(true);
            on.SetActive(false);
            AudioListener.volume = 1;
        }
        if (!check)
        {
            check = false;
            on.SetActive(false);
            on.SetActive(true);
            AudioListener.volume = 0;
        }
    }
}
