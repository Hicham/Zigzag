using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour {

    public GameObject on, off;

    public void OnChangeValue()
    {
        bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
        if (onoffSwitch)
        {
            AudioListener.volume = 1;
            on.SetActive(true);
            on.SetActive(false);
        }
        if (!onoffSwitch)
        {
            AudioListener.volume = 0;
            on.SetActive(false);
            on.SetActive(true);
        }
    }

}
