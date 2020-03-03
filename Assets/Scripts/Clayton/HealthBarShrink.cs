using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BeardedManStudios.Forge.Networking.Unity;

public class HealthBarShrink : MonoBehaviour
{
    private const float DAMAGED_HEALTH_SHRINK_TIMER = 1f;
    private Image barImage;
    private Image damagedBarImage;
    private Image healingBarImage;

    private float damagedHealthShrinkTimer;
    public bool damaged;
    public bool healed;
    public bool healing;
    PlayerDamagedWarning pDW;
    private float playerHealth;
    public ParticleSystem reviveEffect;
    PlayerChangeFace playerFace;

    private void Awake()
    {
        playerHealth = 100f;
        barImage = transform.Find("bar").GetComponent<Image>();
        damagedBarImage = transform.Find("damagedBar").GetComponent<Image>();
        healingBarImage = transform.Find("healingBar").GetComponent<Image>();
        damaged = healed = false;
        pDW = gameObject.transform.parent.parent.GetComponentInChildren<PlayerDamagedWarning>();
        barImage.fillAmount = 1f;
        playerFace = transform.parent.parent.parent.parent.GetComponentInChildren<PlayerChangeFace>();
    }

    public void SetHealth(float healthNormalized) //Set the health to minus
    {
        playerHealth -= healthNormalized;

        if (playerHealth <= 0)
            playerHealth = 0;

        float temp = playerHealth / 100;
        barImage.fillAmount = temp;
        pDW.damaged = true;
        damaged = true;
        playerFace.playerDamaged = true;
    }

    public void IncreaseHealth(float healthNormalized)
    {
        playerHealth += healthNormalized;

        if (playerHealth >= 100)
            playerHealth = 100;

        float temp = playerHealth / 100;
        healingBarImage.fillAmount = temp;
        healed = true;
        healing = true;
    }

    private void UpdateBar()
    {
        if (!healing)
        {
            float temp = playerHealth / 100;
            barImage.fillAmount = temp;
            healingBarImage.fillAmount = barImage.fillAmount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth >= 100)
            playerHealth = 100;

        if (playerHealth <= 0) //Revive player
        {
            Vector3 oldPos = transform.parent.parent.parent.parent.transform.position;
            Destroy(Instantiate(reviveEffect.gameObject, oldPos, reviveEffect.gameObject.transform.rotation) as GameObject, 0.5f);

            transform.parent.parent.parent.parent.transform.position = new Vector3(0, 0, 0);
            Destroy(Instantiate(reviveEffect.gameObject, new Vector3(0, 0, 0), reviveEffect.gameObject.transform.rotation) as GameObject, 0.5f);

            playerHealth = 100;
        }

        UpdateBar();

        damagedHealthShrinkTimer -= Time.deltaTime;

        if (damagedHealthShrinkTimer < 0)
        {
            if (barImage.fillAmount < damagedBarImage.fillAmount && !healing) //If player is damaged
            {
                float shrinkSpeed = 1f;
                damagedBarImage.fillAmount -= shrinkSpeed * Time.deltaTime;
            }
            else
                playerFace.playerDamaged = false;

            if (barImage.fillAmount < healingBarImage.fillAmount && healing) //If player is healed
            {
                float expandSpeed = 1f;
                barImage.fillAmount += expandSpeed * Time.deltaTime;
                damagedBarImage.fillAmount = barImage.fillAmount;
            }
            else 
                healing = false;
        }

        if (damaged)
        {
            damagedHealthShrinkTimer = DAMAGED_HEALTH_SHRINK_TIMER;
            damaged = false;
        }

        if (healed)
        {
            damagedHealthShrinkTimer = DAMAGED_HEALTH_SHRINK_TIMER;
            healed = false;
        }
    }
}