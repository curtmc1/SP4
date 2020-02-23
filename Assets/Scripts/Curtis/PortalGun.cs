using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;

    public GameObject portalParticle;
    public GameObject portalParticle2;

    private bool canShoot;
    public bool p1HasShot;
    public bool p2HasShot;
    public Vector3 portPos;
    public Quaternion portRotation;

    public bool GetCanShoot
    {
        get { return canShoot; }
        set { canShoot = value; }
    }

    private void Start()
    {
        p1HasShot = p2HasShot = false;
    }

    void Update()
    {
        if (!canShoot) return;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(portalParticle, transform.position + 0.5f * transform.forward, transform.rotation);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Wall")
                {
                    GameObject p1 = GameObject.FindGameObjectWithTag("Portal1");
                    Destroy(p1);
                    portPos = hit.transform.position + 2 * hit.transform.forward;
                    portRotation = hit.transform.rotation;
                    Instantiate(portal1, hit.transform.position + 2 * hit.transform.forward, hit.transform.rotation);
                    p1HasShot = true;
                }
            }

        }
        else
            p1HasShot = false;

        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(portalParticle2, transform.position + 0.5f * transform.forward, transform.rotation);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Wall")
                {
                    GameObject p2 = GameObject.FindGameObjectWithTag("Portal2");
                    Destroy(p2);
                    portPos = hit.transform.position + 2 * hit.transform.forward;
                    portRotation = hit.transform.rotation;
                    Instantiate(portal2, hit.transform.position + 2 * hit.transform.forward, hit.transform.rotation);
                    p2HasShot = true;
                }
            }
            
        }
        else
            p2HasShot = false;
    }
}
