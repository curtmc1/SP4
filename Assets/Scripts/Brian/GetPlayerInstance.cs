using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerInstance : MonoBehaviour
{
    //script for testing
    #region Singleton
    public static GetPlayerInstance instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
}
