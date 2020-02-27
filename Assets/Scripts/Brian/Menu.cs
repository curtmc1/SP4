using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public AudioMixer musicMixer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("LevelName", "Level1");
        musicMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
    }

    public void Play()
    {
        //Cursor.visible = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("MultiplayerMenu");
    }

    public void Quit()
    {
        Debug.Log("Quit Game.");
        Application.Quit();
    }
}
