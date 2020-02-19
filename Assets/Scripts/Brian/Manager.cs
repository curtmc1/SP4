using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //script for testing
    #region Singleton
    public static Manager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
    public ParticleSystem particles;

    //if null do something
    
    //Bring over graphic settings for particles
    public void SetQuality()
    {
        int index = PlayerPrefs.GetInt("Graphics");
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

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Graphics"));
        SetQuality();
    }
}
