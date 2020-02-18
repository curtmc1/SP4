using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;

    public float invulnPeriod = 0;
    float invulnTimer = 0;

    //public ParticleSystem deathEffect;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Die();

            //GameObject go = GameObject.FindWithTag("Enemy");

            //if (go != null)
            //{
            //    Instantiate(deathEffect, transform.position, Quaternion.identity);
            //}
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("HIT");
        Debug.Log(collision.gameObject);
        health--;

        if (invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            //gameObject.layer = 10;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
