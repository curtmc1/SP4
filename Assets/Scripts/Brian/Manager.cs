using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    #region Singleton
    public static Manager instance;

    //GameObject player;
    GameObject[] player;

    void Awake()
    {
        instance = this;
    }
    #endregion

    void Update()
    {
        //if (!player)
        //    player = GameObject.FindGameObjectWithTag("Player");

        player = GameObject.FindGameObjectsWithTag("Player");
    }

    //public GameObject[] Player 
    public GameObject[] Player 
    {
        get { return player; }
        set { player = value;}
    }

    //if null do something
}
