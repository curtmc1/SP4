using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //script for testing
    #region Singleton
    public static Manager instance;

    void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    #endregion

    GameObject player;

    public GameObject Player 
    {
        get { return player; }
        set { player = value;}
    }

    //if null do something
}
