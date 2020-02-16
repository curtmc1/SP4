using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brian : MonoBehaviour
{
    //script for testing
    #region Singleton
    public static Brian instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
}
