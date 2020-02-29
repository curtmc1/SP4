using System.Collections;
using System.Collections.Generic;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;
using UnityEngine.Events;

public class AINetwork : AIBehavior
{
    //EnemyMovement enemyMovement;
    EnemyStates enemyStates;
    //EnemyHealth enemyHealth;
    public ParticleSystem deathEffect;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (!networkObject.IsServer) //Disable stuff if AI doesn't belong to server
        {
            //enemyMovement.enabled = false;
            enemyStates.enabled = false;
            //enemyHealth.enabled = false;
        }
    }

    private void Awake()
    {
        //enemyMovement = GetComponentInChildren<EnemyMovement>();
        enemyStates = GetComponentInChildren<EnemyStates>();
        //enemyHealth = GetComponentInChildren<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (networkObject.IsServer) //Send data to server
        {
            networkObject.position = transform.GetChild(0).transform.position;
            networkObject.rotation = transform.GetChild(0).transform.rotation;
            //networkObject.health = enemyHealth.health;
            networkObject.dead = enemyStates.dead;

            //networkObject.invisibleCoolDown = enemyMovement.GetInvisibleCoolDown;
            //networkObject.invisible = enemyMovement.GetInvisible;
            networkObject.distanceaway = enemyStates.GetDistanceaway;
            networkObject.range = enemyStates.range;
        }
        else //Receive
        {
            transform.GetChild(0).transform.position = networkObject.position;
            transform.GetChild(0).transform.rotation = networkObject.rotation;
            //enemyHealth.health = networkObject.health;
            enemyStates.dead = networkObject.dead;

            //enemyMovement.GetInvisibleCoolDown = networkObject.invisibleCoolDown;
            //enemyMovement.GetInvisible = networkObject.invisible;
            enemyStates.GetDistanceaway = networkObject.distanceaway;
            enemyStates.range = networkObject.range;

            if (enemyStates.dead) Destroy(gameObject);
        }
    }
}
