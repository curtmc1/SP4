using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public ParticleSystem particles;
    public Dropdown resolutionDropDown;
    public Dropdown graphicsDropDown;
    public Toggle toggleMenu;
    public Slider sliderRef;

    Resolution[] resolutions;
    Resolution resolution;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentIndex = 0;
        for (int i = 0; i < resolutions.Length; ++i)
        {
            string temp = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(temp);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentIndex = i;
            }

            //if (resolutions[i].width == Screen.currentResolution.width &&
            //    resolutions[i].height == Screen.currentResolution.height)
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentIndex;
        resolutionDropDown.RefreshShownValue();

        //Get player prefs
        //if (PlayerPrefs.HasKey("Graphics"))
        resolution.width = PlayerPrefs.GetInt("ResolutionWidth");
        resolution.height = PlayerPrefs.GetInt("ResolutionHeight");
        sliderRef.value = PlayerPrefs.GetFloat("MasterVolume");
        graphicsDropDown.value =  PlayerPrefs.GetInt("Graphics");
        toggleMenu.isOn = PlayerPrefs.GetInt("bool") == 0 ? false : true;
    }

    public void SetResolution(int index)
    {
        resolution = resolutions[index];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("ResolutionWidth", resolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", resolution.height);
    }

    public void SetVolume(float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
        PlayerPrefs.SetInt("Graphics", index);
        switch (index)
        {
            case 0:
                particles.gameObject.SetActive(false);
                break;
            case 1:
                particles.gameObject.SetActive(false);
                break;
            case 2:
                particles.gameObject.SetActive(false);
                var pce = particles.emission;
                pce.rateOverTime = 5;
                particles.gameObject.SetActive(true);
                break;
            case 3:
                particles.gameObject.SetActive(false);
                pce = particles.emission;
                pce.rateOverTime = 10;
                particles.gameObject.SetActive(true);
                break;
            case 4:
                particles.gameObject.SetActive(false);
                pce = particles.emission;
                pce.rateOverTime = 20;
                particles.gameObject.SetActive(true);
                break;
            case 5:
                particles.gameObject.SetActive(false);
                pce = particles.emission;
                pce.rateOverTime = 30;
                particles.gameObject.SetActive(true);
                break;
        }
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("bool", isFullscreen ? 1 : 0);
    }
}
