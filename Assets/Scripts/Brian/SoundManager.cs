using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static AudioClip pistolsound, portalsound, hitmarkersound, headshotsound, playerdamagesound, ammopickupsound, healthpickupsound;
    static AudioSource audiosource;
    public AudioMixer musicMixer;
    public AudioMixer soundMixer;

    // Start is called before the first frame update
    void Start()
    {
        musicMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        soundMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        pistolsound = Resources.Load<AudioClip>("pistol");
        portalsound = Resources.Load<AudioClip>("portal");
        hitmarkersound = Resources.Load<AudioClip>("hitmarker");
        headshotsound = Resources.Load<AudioClip>("headshot");
        playerdamagesound = Resources.Load<AudioClip>("playerdamage");
        ammopickupsound = Resources.Load<AudioClip>("ammopickup");
        healthpickupsound = Resources.Load<AudioClip>("healthpickup");
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "pistolsound":
                audiosource.PlayOneShot(pistolsound);
                break;
            case "portalsound":
                audiosource.PlayOneShot(portalsound);
                break;
            case "hitmarkersound":
                audiosource.PlayOneShot(hitmarkersound);
                break;
            case "headshotsound":
                audiosource.PlayOneShot(headshotsound);
                break;
            case "playerdamagesound":
                audiosource.PlayOneShot(playerdamagesound);
                break;
            case "ammopickupsound":
                audiosource.PlayOneShot(ammopickupsound);
                break;
            case "healthpickupsound":
                audiosource.PlayOneShot(healthpickupsound);
                break;
        }
    }
}
