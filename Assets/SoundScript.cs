using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource hit, explosion;
    AudioSource bgm;
    void Awake()
    {
        bgm = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Music", 1) == 0)
        {
            bgm.volume = 0;
        }
        if(PlayerPrefs.GetInt("SoundEffect",1) == 0)
        {
            hit.volume = 0;
            explosion.volume = 0;
        }
    }

}
