using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public GameObject laser;
    private float cooldown = 2f;
    private float laserspeed = 50f;

    EnemyStates states;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponent<EnemyStates>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (states.currState == States.state_shoot)
        {
            if (cooldown <= 0f)
            {
                GameObject las = Instantiate(laser, transform.GetChild(4).position, transform.rotation);
                las.GetComponent<Rigidbody>().velocity = transform.forward * laserspeed;
                cooldown = 2f;
            }
        }
    }
}
