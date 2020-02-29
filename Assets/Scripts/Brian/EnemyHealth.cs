using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;

public class EnemyHealth : EnemyHealthBehavior
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
        if (networkObject.IsServer) 
        {
            networkObject.health = health;

            if (states.currState == States.state_dead)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
            }

        }
        else
        {
            health = networkObject.health;

            if (health <= 0)
                Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }
}
