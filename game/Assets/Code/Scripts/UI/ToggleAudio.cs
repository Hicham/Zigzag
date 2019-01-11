using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToggleAudio : MonoBehaviour {

    public Button button;
    public Sprite On;
    public Sprite Off;
    public bool OnOffSwitch;

    public void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnChangeValue()
    {
        if (OnOffSwitch)
        {
            OnOffSwitch = false;
            button.image.overrideSprite = Off;
            AudioListener.volume = 1;
            Debug.Log(AudioListener.volume);
        }
        else if (!OnOffSwitch)
        {
            OnOffSwitch = true;
            button.image.overrideSprite = On;
            AudioListener.volume = 0;
            Debug.Log(AudioListener.volume);
        }
    }
}
