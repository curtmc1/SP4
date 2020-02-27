using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
public class EnvironmentalObject : EnvironmentalBehavior
{
    public bool isServer;
    public bool isClient;

    // Start is called before the first frame update
    void Start()
    {
        isServer = isClient = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Manager.instance.Player.Length; i++)
        {
            if (Manager.instance.Player[i].GetComponentInChildren<PortalGun>().isClient)
                isClient = true;
            else if (Manager.instance.Player[i].GetComponentInChildren<PortalGun>().isServer)
                isServer = true;
        }

        //Debug.Log("IsServer: " + isServer + " IsClient: " + isClient);

        if (isServer)
        {
            if (!networkObject.IsServer)
            {
                transform.position = networkObject.position;
                transform.rotation = networkObject.rotation;
                return;
            }

            networkObject.position = transform.position;
            networkObject.rotation = transform.rotation;
        }

        if (isClient)
        {
            if (networkObject.IsServer)
            {
                transform.position = networkObject.position;
                transform.rotation = networkObject.rotation;
                return;
            }

            networkObject.position = transform.position;
            networkObject.rotation = transform.rotation;
        }
    }
}
