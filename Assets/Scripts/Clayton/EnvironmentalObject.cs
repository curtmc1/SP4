using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;

public class EnvironmentalObject : EnvironmentalBehavior
{
    public bool isServer;
    public bool isClient;
    public string naming;
    private bool forServer;
    private bool forClient;


    // Start is called before the first frame update
    void Start()
    {
        isServer = isClient = forServer = forClient = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Basically if player pickup item and player is the server then send data to other player and 
        //if player pickup item and player is not server then send data to server
        //If item was picked up by someone, the person will send data till the item stops moving
        //When Item is picked up, gravity is turned off (Enabled when Item is not picked up) as the gravity will mess up the data received on the other side

        if (networkObject.IsServer) //If server
        {
            if (isServer) // If item is picked up by player from the server, disable gravity
            {
                networkObject.SendRpc(RPC_UPDATE_CLIENT, Receivers.AllBuffered, transform.position, transform.rotation, isServer);
                forServer = true;
            }
            else if (!isServer && !isClient) //If no one pick up item
            {
                if (gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero && forServer) //If still got movement then continue sending data
                    networkObject.SendRpc(RPC_UPDATE_CLIENT, Receivers.AllBuffered, transform.position, transform.rotation, isServer);
                else
                {
                    forServer = false; //when Item is stationary then add gravity
                    networkObject.SendRpc(RPC_USE_GRAVITY_CLIENT, Receivers.AllBuffered, true);
                }
            }
        }
        else
        {
            if (isClient)
            {
                networkObject.SendRpc(RPC_UPDATE_SERVER, Receivers.AllBuffered, transform.position, transform.rotation, isClient);
                forClient = true;
            }
            else if (!isServer && !isClient)
            {
                if (gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero && forClient)
                    networkObject.SendRpc(RPC_UPDATE_SERVER, Receivers.AllBuffered, transform.position, transform.rotation, isClient);
                else
                {
                    forClient = false;
                    networkObject.SendRpc(RPC_USE_GRAVITY_SERVER, Receivers.AllBuffered, true);
                }
            }
        }
    }

    public override void UpdateServer(RpcArgs args)
    {
        //For server to update pos
        if (!networkObject.IsServer) return;

        Vector3 pos = args.GetNext<Vector3>();
        Quaternion rot = args.GetNext<Quaternion>();
        bool trueOrNot = args.GetNext<bool>();

        if (!isServer)
        {
            isClient = trueOrNot;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
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
        bool trueOrNot = args.GetNext<bool>();

        if (!isClient)
        {
            isServer = trueOrNot;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            transform.position = pos;
            transform.rotation = rot;
        }
    }

    public override void UseGravityServer(RpcArgs args)
    {
        //For server to update Gravity
        if (!networkObject.IsServer) return;

        bool gravity = args.GetNext<bool>();

        if (!isServer)
        {
            if (gameObject.GetComponent<Rigidbody>().useGravity == false)
                gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public override void UseGravityClient(RpcArgs args)
    {
        //For Client to update Gravity
        if (networkObject.IsServer) return;

        bool gravity = args.GetNext<bool>();

        if (!isClient)
        {
            if (gameObject.GetComponent<Rigidbody>().useGravity == false)
                gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
