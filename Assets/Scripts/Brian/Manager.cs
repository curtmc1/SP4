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

    public GameObject player;

    //if null do something
}
