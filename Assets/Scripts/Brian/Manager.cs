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

    private GameObject player;

    public GameObject Player 
    {
        get { return player; }
        set { player = value;}
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //if null do something
}
