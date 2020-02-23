using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("MultiplayerMenu");
        //Cursor.visible = false;
    }

    public void Quit()
    {
        Debug.Log("Quit Game.");
        Application.Quit();
    }
}
