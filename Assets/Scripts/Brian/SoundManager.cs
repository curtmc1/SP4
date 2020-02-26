using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip pistolsound;
    static AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        pistolsound = Resources.Load<AudioClip>("pistol");
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
        }
    }
}
