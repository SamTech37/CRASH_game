using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public Toggle music, soundEffect;
    void Start()
    {
        music.isOn = PlayerPrefs.GetInt("Music", 1) == 1 ? true : false;
        soundEffect.isOn = PlayerPrefs.GetInt("SoundEffect", 1) == 1 ? true : false;
        music.onValueChanged.AddListener(isOn => PlayerPrefs.SetInt("Music", isOn ? 1 : 0));
        soundEffect.onValueChanged.AddListener(isOn => PlayerPrefs.SetInt("SoundEffect", isOn ? 1 : 0) );

    }


}
