﻿using System.Collections;
using System.Collections.Generic;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine;

public enum States
{
    state_roam,
    state_underattack,
    state_chase,
    state_shoot,
    state_stalk,
    state_dead
}

public class EnemyStates : MonoBehaviour
{
    public States currState;

    Transform player;

    public float range = 10f;

    float distanceaway = float.MaxValue; //changed to max value, if default value below 20, enemy will spawn in attack state instead of roam
    public event System.Action OnDeath;
    public bool dead;

    public float GetDistanceaway
    {
        get { return distanceaway; }
        set { distanceaway = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        currState = States.state_roam;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!NetworkManager.Instance.IsServer) return;

        for (int i = 0; i < Manager.instance.Player.Length; i++)
        {
            float dist = Vector3.Distance(Manager.instance.Player[i].transform.position, transform.position);

            if (dist < 20)
                player = Manager.instance.Player[i].transform;
        }

        if (player != null)
            distanceaway = Vector3.Distance(player.position, transform.position);

        EnemyHealth enemyhp = GetComponent<EnemyHealth>();

        switch (currState)
        {
            case States.state_roam:
                if (distanceaway < range)
                    currState = States.state_chase;
                if (gameObject.name == ("EnemySoldier"))
                {
                    if (distanceaway < range)
                        currState = States.state_shoot;
                }
                if (gameObject.name == ("EnemyStalker"))
                {
                    if (distanceaway < range)
                        currState = States.state_stalk;
                }
                if (enemyhp.health <= 0)
                {
                    dead = true;
                    currState = States.state_dead;
                }
                break;
            case States.state_underattack:
                break;
            case States.state_chase:
                if (distanceaway > range)
                    currState = States.state_roam;
                if (enemyhp.health <= 0)
                {
                    dead = true;
                    currState = States.state_dead;
                }
                break;
            case States.state_shoot:
                if (distanceaway > range)
                    currState = States.state_roam;
                if (enemyhp.health <= 0)
                {
                    dead = true;
                    currState = States.state_dead;
                }
                break;
            case States.state_stalk:
                if (distanceaway > range)
                    currState = States.state_roam;
                if (enemyhp.health <= 0)
                {
                    dead = true;
                    currState = States.state_dead;
                }
                break;
            case States.state_dead:
                Die();
                break;
        }
    }

    void Die()
    {
        OnDeath?.Invoke();
        Destroy(transform.parent.gameObject);
    }
}
