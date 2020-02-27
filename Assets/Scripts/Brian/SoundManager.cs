using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static AudioClip pistolsound, headshotsound;
    static AudioSource audiosource;
    public AudioMixer musicMixer;
    public AudioMixer soundMixer;

    // Start is called before the first frame update
    void Start()
    {
        musicMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        soundMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        pistolsound = Resources.Load<AudioClip>("pistol");
        headshotsound = Resources.Load<AudioClip>("headshot");
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
            case "headshotsound":
                audiosource.PlayOneShot(headshotsound);
                break;
        }
    }
}
