using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    private HealthBarShrink hpbar;
    private Item item;
    private bool canHeal = false;
    private float coolDown = 5.0f;
    private float coolDownTimer;

    void Start()
    {
        hpbar = (HealthBarShrink)FindObjectOfType(typeof(HealthBarShrink));
    }

    void Update()
    {
        if (coolDownTimer > 0.0f)
            coolDownTimer -= Time.deltaTime;
        if (coolDownTimer < 0)
            coolDownTimer = 0.0f;

        if (Input.GetKeyUp(KeyCode.G) && coolDownTimer == 0)
        {
            hpbar.IncreaseHealth(20);
            coolDownTimer = coolDown;
        }
    }
}
