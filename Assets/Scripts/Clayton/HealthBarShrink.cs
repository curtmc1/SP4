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
    public bool damaged;
    public bool healed;

    private void Awake()
    {
        PlayerPrefs.SetFloat("playerHealth", 100); //ensures that player starts with 100 hp, and that previous hp is not brought back
        barImage = transform.Find("bar").GetComponent<Image>();
        damagedBarImage = transform.Find("damagedBar").GetComponent<Image>();
        damaged = healed = false;
    }

    public void SetHealth(float healthNormalized) //changed to public so can be used outside of current script
    {
        //barImage.fillAmount = healthNormalized;
        PlayerPrefs.SetFloat("playerHealth", PlayerPrefs.GetFloat("playerHealth") - healthNormalized);
        float temp = PlayerPrefs.GetFloat("playerHealth") / 100;
        barImage.fillAmount = temp;
    }

    private void UpdateBar()
    {
        //placeHolder = PlayerPrefs.GetFloat("playerHealth");
        float temp = PlayerPrefs.GetFloat("playerHealth") / 100;
        barImage.fillAmount = temp;
    }

    // Start is called before the first frame update
    void Start()
    {        
        float temp = PlayerPrefs.GetFloat("playerHealth") / 100f;
        barImage.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBar();
        damagedHealthShrinkTimer -= Time.deltaTime;
        if (damagedHealthShrinkTimer < 0)
        {
            if (barImage.fillAmount < damagedBarImage.fillAmount)
            {
                float shrinkSpeed = 1f;
                damagedBarImage.fillAmount -= shrinkSpeed * Time.deltaTime;
            }
        }

        if (damaged)
        {
            damagedHealthShrinkTimer = DAMAGED_HEALTH_SHRINK_TIMER;
            damaged = false;
        }

        if (healed)
        {
            damagedBarImage.fillAmount = barImage.fillAmount;
            healed = false;
        }

        //Testing
        //heal
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerPrefs.SetFloat("playerHealth", PlayerPrefs.GetFloat("playerHealth") + 50);
            healed = true;
        }

        //Damage
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            damaged = true;
            PlayerPrefs.SetFloat("playerHealth", PlayerPrefs.GetFloat("playerHealth") - 50);
        }
    }
}