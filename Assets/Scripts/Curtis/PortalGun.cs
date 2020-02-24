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
    private new GameObject camera;
    private GameObject objectHeld;
    private bool isHeld;

    public bool GetCanShoot
    {
        get { return canShoot; }
        set { canShoot = value; }
    }

    public bool GetIsHeld
    {
        get { return isHeld; }
        set { isHeld = value; }
    }

    private void Start()
    {
        p1HasShot = p2HasShot = false;
        camera = transform.parent.parent.parent.GetChild(0).gameObject;
        isHeld = false;
    }

    void Update()
    {
        Ray ray = camera.transform.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (!canShoot) return;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(portalParticle, transform.position + 0.5f * transform.forward, transform.rotation);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
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
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
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

        if (Input.GetMouseButtonDown(2))
        {
            isHeld = !isHeld;

            if (isHeld)
            {
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 5))
                {
                    if (hit.transform.GetComponent<Rigidbody>() != null)
                    {
                        objectHeld = hit.transform.gameObject;
                        hit.transform.position = camera.transform.position + 2 * camera.transform.forward;
                    }
                }
            }
        }

        if (!isHeld)
        {
            objectHeld = null;
        }

        if (objectHeld)
        {
            objectHeld.transform.position = camera.transform.position + 2 * camera.transform.forward;

            if (Input.GetKeyDown(KeyCode.E))
            {
                isHeld = false;
                objectHeld.GetComponent<Rigidbody>().velocity = 10 * camera.transform.forward;
            }
        }
    }
}
