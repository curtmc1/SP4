using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;

    public ParticleSystem deathEffect;

    EnemyStates states;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponent<EnemyStates>();
    }

    // Update is called once per frame
    void Update()
    {
        if (states.currState == States.state_dead)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }
}
