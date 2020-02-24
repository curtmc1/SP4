using System.Collections;
using System.Collections.Generic;
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

    float distanceaway = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currState = States.state_roam;

        //player = Manager.instance.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            player = Manager.instance.Player.transform;

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
                    currState = States.state_dead;
                    break;
            case States.state_chase:
                if (distanceaway > range)
                    currState = States.state_roam;
                if (enemyhp.health <= 0)
                    currState = States.state_dead;
                break;
            case States.state_shoot:
                if (distanceaway > range)
                    currState = States.state_roam;
                if (enemyhp.health <= 0)
                    currState = States.state_dead;
                break;
            case States.state_stalk:
                if (distanceaway > range)
                    currState = States.state_roam;
                if (enemyhp.health <= 0)
                    currState = States.state_dead;
                break;
            case States.state_dead:
                Die();
                break;
        }
    }

    void Die()
    {
        Destroy(transform.parent.gameObject);
    }
}
