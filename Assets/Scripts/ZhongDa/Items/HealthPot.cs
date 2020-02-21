using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    public GameObject healthPot;
    private HealthBarShrink obj;
    private float health = 30.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //PlayerPrefs.SetFloat("playerHealth", PlayerPrefs.GetFloat("playerHealth") + health);
            //obj.GetComponent<HealthBarShrink>().healed = true;
        }
    }
}
