﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sliderSFX, sliderBG;
    public AudioSource sfx1, sfx2;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SFX_Vol"))
        {
            sliderSFX.value = PlayerPrefs.GetFloat("SFX_Vol");
        }
        if (PlayerPrefs.HasKey("BG_Vol"))
        {
            sliderBG.value = PlayerPrefs.GetFloat("BG_Vol");
        }
    }

    // Update is called once per frame
    void Update()
    {
        mixer.SetFloat("SFX", sliderSFX.value);
        mixer.SetFloat("BG", sliderBG.value);
    }

    public void SFXTest()
    {
        if (!sfx2.isPlaying)
        {
            sfx1.Play();
            sfx2.Play();
        }
    }

    public void ResetSFX()
    {
        sliderSFX.value = 0;
    }

    public void ResetBG()
    {
        sliderBG.value = 0;
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("SFX_Vol", sliderSFX.value);
        PlayerPrefs.SetFloat("BG_Vol", sliderBG.value);
        PlayerPrefs.Save();
    }
}
