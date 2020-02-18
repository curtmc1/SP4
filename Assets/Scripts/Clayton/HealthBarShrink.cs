using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarShrink : MonoBehaviour
{
    private const float DAMAGED_HEALTH_SHRINK_TIMER = 1f;
    private Image barImage;
    private Image damagedBarImage;
    private float damagedHealthShrinkTimer;

    private void Awake()
    {
        barImage = transform.Find("bar").GetComponent<Image>();
        damagedBarImage = transform.Find("damagedBar").GetComponent<Image>();
    }

    private void SetHealth(float healthNormalized)
    {
        //barImage.fillAmount = healthNormalized;
        PlayerPrefs.SetFloat("playerHealth", PlayerPrefs.GetFloat("playerHealth") - healthNormalized);
        float temp = PlayerPrefs.GetFloat("playerHealth") / 100;
        barImage.fillAmount = temp;
    }

    // Start is called before the first frame update
    void Start()
    {
        float temp = PlayerPrefs.GetFloat("playerHealth") / 100f;
        barImage.fillAmount = temp;
    }

    // Update is called once per frame
    void Update()
    {
        damagedHealthShrinkTimer -= Time.deltaTime;
        if (damagedHealthShrinkTimer < 0)
        {
            if (barImage.fillAmount < damagedBarImage.fillAmount)
            {
                float shrinkSpeed = 1f;
                damagedBarImage.fillAmount -= shrinkSpeed * Time.deltaTime;
            }
        }

        //Testing
        //heal
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetHealth(80f);
            damagedBarImage.fillAmount = barImage.fillAmount;
        }

        //Damage
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            damagedHealthShrinkTimer = DAMAGED_HEALTH_SHRINK_TIMER;
            SetHealth(50f);
        }
    }
}
