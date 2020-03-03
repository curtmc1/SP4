using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using BeardedManStudios.Forge.Networking;

public class PlayerChangeFace : PlayerChangeFaceBehavior
{
    public bool playerDamaged;

    // Start is called before the first frame update
    void Start()
    {
        playerDamaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (networkObject.IsOwner)
        {
            networkObject.position = transform.position;
            networkObject.rotation = transform.rotation;

            if (playerDamaged) //Change face
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);

                networkObject.SendRpc(RPC_CHANGE_FACE, Receivers.AllBuffered, false, true);
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);

                networkObject.SendRpc(RPC_CHANGE_FACE, Receivers.AllBuffered, true, false);
            }
        }
        else
        {
            transform.position = networkObject.position;
            transform.rotation = networkObject.rotation;
        }
    }

    public override void ChangeFace(RpcArgs args) //Receive data to change face
    {
        if (networkObject.IsOwner) return;

        bool childZero = args.GetNext<bool>();
        bool childOne = args.GetNext<bool>();

        gameObject.transform.GetChild(0).gameObject.SetActive(childZero);
        gameObject.transform.GetChild(1).gameObject.SetActive(childOne);
    }
}
