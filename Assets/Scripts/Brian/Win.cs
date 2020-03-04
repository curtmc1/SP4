using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject WinMenu;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<CheckWin>().reachedEnd)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            WinMenu.SetActive(true);
        }
    }

    public void LoadMenu()
    {
        gameObject.GetComponentInParent<CheckWin>().reachedEnd = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Quit Game.");
        Application.Quit();
    }
}
