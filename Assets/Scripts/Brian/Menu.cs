using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("LevelName", "Level1");
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
