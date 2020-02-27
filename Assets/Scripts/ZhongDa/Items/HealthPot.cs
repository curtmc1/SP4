using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPot : MonoBehaviour
{
    public Text coolDownText;
    private HealthBarShrink hpbar;
    private bool canHeal = false;
    private float coolDown = 5.0f;
    private float coolDownTimer;


    void Start()
    {
        hpbar = (HealthBarShrink)FindObjectOfType(typeof(HealthBarShrink));
        coolDownText.enabled = false;
    }

    void Update()
    {
        int timer = (int)coolDownTimer;
        coolDownText.text = timer.ToString();

        if (coolDownTimer > 0.0f)
            coolDownTimer -= Time.deltaTime;
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0.0f;
            coolDownText.enabled = false;
        }

        if (coolDownTimer == 5.0f)
            coolDownText.enabled = false;

        if (Input.GetKeyUp(KeyCode.G) && coolDownTimer == 0)
        {
            coolDownText.enabled = true;
            hpbar.IncreaseHealth(20);
            coolDownTimer = coolDown;
        }

    }
}
