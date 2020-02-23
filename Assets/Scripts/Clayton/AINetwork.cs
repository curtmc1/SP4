using System.Collections;
using System.Collections.Generic;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;
using UnityEngine;

public class AINetwork : AIBehavior
{
    EnemyHealth enemyHealth;

    //protected override void NetworkStart()
    //{
    //    base.NetworkStart();
    //}

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (networkObject.IsOwner)
        {
            networkObject.position = transform.position;
            networkObject.rotation = transform.rotation;
            networkObject.health = enemyHealth.health;
        }
        else
        {
            transform.position = networkObject.position;
            transform.rotation = networkObject.rotation;
            enemyHealth.health = networkObject.health;
        }
    }
}
