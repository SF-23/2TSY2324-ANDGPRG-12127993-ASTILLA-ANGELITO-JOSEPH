using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] bool isEnableSound = true;

    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider masterSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    [SerializeField] TextMeshProUGUI muteTxt;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            EnableSound();
        }
    }

    public void EnableSound()
    {
        if (!isEnableSound)
        {
            isEnableSound = true;
            muteTxt.text = "SOUND OFF";
            AudioListener.pause = true;
        }
        else
        {
            isEnableSound = false;
            muteTxt.text = "SOUND ON";
            AudioListener.pause = false;
        }
    }

    public void ChangeMasterVolume()
    {
        ChangeVolume("MasterVol", masterSlider.value);
    }

    public void ChangeBGMVolume()
    {
        ChangeVolume("BGMVol", bgmSlider.value);
    }

    public void ChangeSFXVolume()
    {
        ChangeVolume("SFXVol", sfxSlider.value);
    }

    void ChangeVolume(string name, float value)
    {
        float dbVolume = Mathf.Log10(value) * 20;

        if (value == 0.0f)
        {
            dbVolume = -80.0f;
        }

        audioMixer.SetFloat(name, dbVolume);
    }
}
