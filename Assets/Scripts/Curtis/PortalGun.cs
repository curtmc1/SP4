using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;

public class PortalGun : GunBehavior
{
    public GameObject portal1;
    public GameObject portal2;

    public GameObject portalParticle;
    public GameObject portalParticle2;

    private bool canShoot;
    private new GameObject camera;
    private GameObject objectHeld;
    private bool isHeld;
    private Vector3 pos;

    PortalUI portUI;

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
        camera = transform.parent.parent.parent.GetChild(0).gameObject;
        isHeld = false;
        portUI = gameObject.transform.parent.parent.GetComponentInChildren<PortalUI>();
        portUI.ammo = 30;
    }

    void Update()
    {
        if (!networkObject.IsOwner) return;

        Ray ray = camera.transform.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (!canShoot) return;

        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.PlaySound("portalsound");
            Instantiate(portalParticle, transform.position + 0.5f * transform.forward, transform.rotation);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Wall")
                {
                    GameObject p1 = GameObject.FindGameObjectWithTag("Portal1");
                    Destroy(p1);
                    Instantiate(portal1, hit.point + 2 * hit.transform.forward, hit.transform.rotation);
                    pos = hit.point + 2 * hit.transform.forward;
                    networkObject.SendRpc(RPC_SHOOT, Receivers.AllBuffered, pos, hit.transform.rotation, pos, "portal1");
                    portUI.canDisplay1 = true;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            SoundManager.PlaySound("portalsound");
            Instantiate(portalParticle2, transform.position + 0.5f * transform.forward, transform.rotation);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Wall")
                {
                    GameObject p2 = GameObject.FindGameObjectWithTag("Portal2");
                    Destroy(p2);
                    Instantiate(portal2, hit.point + 2 * hit.transform.forward, hit.transform.rotation);
                    pos = hit.point + 2 * hit.transform.forward;
                    networkObject.SendRpc(RPC_SHOOT, Receivers.AllBuffered, pos, hit.transform.rotation, pos, "portal2");
                    portUI.canDisplay2 = true;
                }
            }
            
        }

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

                        if (networkObject.IsServer)
                        {
                            //objectHeld.transform.gameObject.GetComponent<EnvironmentalObject>().naming = "Server";
                            objectHeld.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
                            objectHeld.transform.gameObject.GetComponent<EnvironmentalObject>().isServer = true;
                            objectHeld.transform.gameObject.GetComponent<EnvironmentalObject>().isClient = false;
                        }

                        if (!networkObject.IsServer)
                        {
                            //objectHeld.transform.gameObject.GetComponent<EnvironmentalObject>().naming = "Client";
                            objectHeld.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
                            objectHeld.transform.gameObject.GetComponent<EnvironmentalObject>().isClient = true;
                            objectHeld.transform.gameObject.GetComponent<EnvironmentalObject>().isServer = false;
                        }

                        hit.transform.position = camera.transform.position + 2 * camera.transform.forward;
                    }
                }
            }
        }

        if (!isHeld && objectHeld)
        {
            if (objectHeld.transform.gameObject.GetComponent<EnvironmentalObject>().isServer)
                objectHeld.transform.gameObject.GetComponent<EnvironmentalObject>().isServer = false;

            if (objectHeld.transform.gameObject.GetComponent<EnvironmentalObject>().isClient)
                objectHeld.transform.gameObject.GetComponent<EnvironmentalObject>().isClient = false;

            objectHeld.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;

            objectHeld = null;
        }

        if (objectHeld)
        {
            objectHeld.transform.position = camera.transform.position + 2 * camera.transform.forward;

            if (Input.GetKeyDown(KeyCode.E))
            {
                isHeld = false;
                objectHeld.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;
                objectHeld.GetComponent<Rigidbody>().velocity = 10 * camera.transform.forward;
            }
        }
    }

    public override void Shoot(RpcArgs args)
    {
        if (networkObject.IsOwner) return;

        Vector3 pos = args.GetNext<Vector3>();
        Quaternion rot = args.GetNext<Quaternion>();
        Vector3 forward = args.GetNext<Vector3>();
        string name = args.GetNext<string>();

        if (name == "portal1")
        {
            GameObject p1 = GameObject.FindGameObjectWithTag("Portal1");
            Destroy(p1);
            Instantiate(portal1, pos, rot);
        }
        else if (name == "portal2")
        {
            GameObject p2 = GameObject.FindGameObjectWithTag("Portal2");
            Destroy(p2);
            Instantiate(portal2, pos, rot);
        }
    }

    public override void Object(RpcArgs args)
    {
    }
}
