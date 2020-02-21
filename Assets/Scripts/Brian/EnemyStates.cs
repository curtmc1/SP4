using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    state_roam,
    state_chase,
    state_shoot,
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

        player = Manager.instance.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceaway = Vector3.Distance(player.position, transform.position);

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
                break;
            case States.state_chase:
                if (distanceaway > range)
                    currState = States.state_roam;
                break;
            case States.state_shoot:
                if (distanceaway > range)
                    currState = States.state_roam;
                break;
            case States.state_dead:
                break;
        }
    }
}
