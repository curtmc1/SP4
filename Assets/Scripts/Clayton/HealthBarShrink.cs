using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarShrink : MonoBehaviour
{
    private const float DAMAGED_HEALTH_SHRINK_TIMER = 1f;
    private Image barImage;
    private Image damagedBarImage;
    private Image damagedWarning;
    private float damagedHealthShrinkTimer;
    public bool damaged;
    public bool healed;

    private void Awake()
    {
        PlayerPrefs.SetFloat("playerHealth", 100); //ensures that player starts with 100 hp, and that previous hp is not brought back
        barImage = transform.Find("bar").GetComponent<Image>();
        damagedBarImage = transform.Find("damagedBar").GetComponent<Image>();
        damagedWarning = transform.Find("damagedWarning").GetComponent<Image>();
        damagedWarning.gameObject.SetActive(false);
        damaged = healed = false;
    }

    public void SetHealth(float healthNormalized) //changed to public so can be used outside of current script
    {
        //barImage.fillAmount = healthNormalized;
        PlayerPrefs.SetFloat("playerHealth", PlayerPrefs.GetFloat("playerHealth") - healthNormalized);
        float temp = PlayerPrefs.GetFloat("playerHealth") / 100;
        barImage.fillAmount = temp;
        damaged = true;
    }

    public void IncreaseHealth(float healthNormalized) //changed to public so can be used outside of current script
    {
        PlayerPrefs.SetFloat("playerHealth", PlayerPrefs.GetFloat("playerHealth") + healthNormalized);
        float temp = PlayerPrefs.GetFloat("playerHealth") / 100;
        barImage.fillAmount = temp;
        healed = true;
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
                damagedWarning.gameObject.SetActive(true);
            }
            else
                damagedWarning.gameObject.SetActive(false);
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
    }
}