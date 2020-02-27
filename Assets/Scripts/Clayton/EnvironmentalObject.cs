using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;

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
        //if (networkObject.IsServer)
        //{
        //    //Server side

        //    if (isServer) //if server pick up
        //        networkObject.SendRpc(RPC_UPDATE_CLIENT, Receivers.AllBuffered, transform.position, transform.rotation);
        //}
        //else
        //{
        //    //Client side
        //    if (isClient) //if client pick up
        //        networkObject.SendRpc(RPC_UPDATE_SERVER, Receivers.AllBuffered, transform.position, transform.rotation);
        //}

        if (networkObject.IsServer)
        {
            //Server side

            if (isServer) //if server pick up
            {
                networkObject.SendRpc(RPC_UPDATE_CLIENT, Receivers.AllBuffered, transform.position, transform.rotation);
                //networkObject.position = transform.position;
                //networkObject.rotation = transform.rotation;
            }
            //else
            //{
            //    transform.position = networkObject.position;
            //    transform.rotation = networkObject.rotation;
            //}

        }
        else
        {
            //Client side
            if (isClient) //if client pick up
            {
                networkObject.SendRpc(RPC_UPDATE_SERVER, Receivers.AllBuffered, transform.position, transform.rotation);
                //networkObject.position = transform.position;
                //networkObject.rotation = transform.rotation;
            }
            //else
            //{
            //    transform.position = networkObject.position;
            //    transform.rotation = networkObject.rotation;
            //}

        }
    }

    public override void UpdateServer(RpcArgs args)
    {
        //For server to update pos
        if (!networkObject.IsServer) return;

        Vector3 pos = args.GetNext<Vector3>();
        Quaternion rot = args.GetNext<Quaternion>();

        if (!isServer)
        {
            transform.position = pos;
            transform.rotation = rot;
        }
    }

    public override void UpdateClient(RpcArgs args)
    {
        //For Client to update pos
        if (networkObject.IsServer) return;

        Vector3 pos = args.GetNext<Vector3>();
        Quaternion rot = args.GetNext<Quaternion>();

        if (!isClient)
        {
            transform.position = pos;
            transform.rotation = rot;
        }
    }
}
