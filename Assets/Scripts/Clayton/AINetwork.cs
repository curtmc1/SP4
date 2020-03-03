using System.Collections;
using System.Collections.Generic;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;
using UnityEngine.Events;

public class AINetwork : AIBehavior
{
    EnemyStates enemyStates;
    public ParticleSystem deathEffect;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (!networkObject.IsServer) //Disable stuff if AI doesn't belong to server
            enemyStates.enabled = false;
    }

    private void Awake()
    {
        enemyStates = GetComponentInChildren<EnemyStates>();
    }

    // Update is called once per frame
    void Update()
    {
        if (networkObject.IsServer) //Send data to server
        {
            networkObject.position = transform.GetChild(0).transform.position;
            networkObject.rotation = transform.GetChild(0).transform.rotation;
            networkObject.dead = enemyStates.dead;
            networkObject.distanceaway = enemyStates.GetDistanceaway;
            networkObject.range = enemyStates.range;
        }
        else //Receive
        {
            transform.GetChild(0).transform.position = networkObject.position;
            transform.GetChild(0).transform.rotation = networkObject.rotation;
            enemyStates.dead = networkObject.dead;

            enemyStates.GetDistanceaway = networkObject.distanceaway;
            enemyStates.range = networkObject.range;

            if (enemyStates.dead) Destroy(gameObject);
        }
    }
}
