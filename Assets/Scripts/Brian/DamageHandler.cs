using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float invulnPeriod = 0;
    float invulnTimer = 0;

    HealthBarShrink hpbar;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat("playerHealth"));
        hpbar = (HealthBarShrink)FindObjectOfType(typeof(HealthBarShrink));
    }

    // Update is called once per frame
    void Update()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("HIT");
        Debug.Log(collision.gameObject);

        if (hpbar && gameObject.tag == "Enemy")
        {
            if (collision.gameObject.name == "First person player")
            {
                //GameObject.Find("HealthBarShrink").GetComponent<HealthBarShrink>.healed = true;
                hpbar.SetHealth(10);
                Debug.Log(PlayerPrefs.GetFloat("playerHealth"));
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyhp = collision.gameObject.GetComponent<EnemyHealth>();
            enemyhp.health--;
            Debug.Log("Damaged");
        }

        if (invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            //gameObject.layer = 10;
        }
    }
}
