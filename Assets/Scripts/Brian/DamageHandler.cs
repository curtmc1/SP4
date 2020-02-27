using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float invulnPeriod = 0f;
    float invulnTimer = 0f;

    //HealthBarShrink hpbar;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(PlayerPrefs.GetFloat("playerHealth"));

        if (invulnPeriod > 0f)
        {
            invulnTimer = invulnPeriod;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (!hpbar)
        //    hpbar = (HealthBarShrink)FindObjectOfType(typeof(HealthBarShrink));

        if (invulnTimer > 0f)
        {
            invulnTimer -= Time.deltaTime;
        }
    }

    void OnTriggerStay(Collider collision)
    {
        //Debug.Log("HIT");
        //Debug.Log(collision.gameObject);

        //Enemy attack Player
        if (/*hpbar && */gameObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                if (invulnTimer <= 0f)
                {
                    //hpbar.SetHealth(10);
                    collision.gameObject.GetComponentInChildren<HealthBarShrink>().SetHealth(10);
                    invulnTimer = invulnPeriod;
                }
                //Debug.Log(PlayerPrefs.GetFloat("playerHealth"));
            }
        }

        //Bullet hit Enemy
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyhp = collision.gameObject.GetComponent<EnemyHealth>();
            enemyhp.health--;
            //Debug.Log("Damaged");
        }
        else if (collision.gameObject.tag == "EnemyHead")
        {
            SoundManager.PlaySound("headshotsound");
            EnemyHealth enemyhp = collision.gameObject.GetComponentInParent<EnemyHealth>();
            enemyhp.health -= 3;
            //Debug.Log("Damaged");
        }
    }
}
