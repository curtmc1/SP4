using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer laser;
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        laser.SetPosition(0, transform.position);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                if (hit.transform.tag == "Player")
                {
                    hit.transform.GetComponentInChildren<HealthBarShrink>().SetHealth(100);
                }
                else if (hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyHealth>().health = 0;
                }
                laser.SetPosition(1, hit.point);
            }
        }
        else laser.SetPosition(1, transform.forward * 5000);
    }
}
