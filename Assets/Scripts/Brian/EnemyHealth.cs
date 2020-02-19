using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
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

    void Die()
    {
        Destroy(gameObject);
    }
}
