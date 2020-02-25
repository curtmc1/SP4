using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerNetwork : PlayerBehavior
{
    [System.Serializable] public class ToggleEvent : UnityEvent<bool> { } //using Unity event
    public Text nameUI;

    [SerializeField] private GameObject playerModel;
    [SerializeField] private GameObject playerHUD;
    [SerializeField] ToggleEvent ownerScripts;
    private string playerName;
    //public string PlayerName { get { return playerName; } }
    private Camera playerCamera;

    public bool IsNotOwner()
    {
        return !networkObject.IsOwner;
    }

    public void Naming()
    {
        if (!networkObject.IsOwner) return;

        string playerName = PlayerPrefs.GetString("PlayerName");
        networkObject.SendRpc(RPC_SETUP_PLAYER, Receivers.AllBuffered, playerName); //Send to server
    }

    //When the network starts
    protected override void NetworkStart()
    {
        base.NetworkStart();
        //Make a dynamic bool depending on we are the owner or not, and define the logic in the inspector as some scripts should be disabled on non owners
        //Owner is a Forge Networking thing. Owner is like if player 1 is on window 1 then player 1 is the owner while player 2 is not but in window 2, player 2 is the owner while player 1 is not
        ownerScripts.Invoke(networkObject.IsOwner);

        playerCamera = GetComponentInChildren<Camera>();

        if (!networkObject.IsOwner)
        {
            Destroy(playerCamera.GetComponent<AudioListener>());
            playerCamera.gameObject.SetActive(false);
        }
        else if (networkObject.IsOwner)
        {
            playerHUD.SetActive(true);
        }

        Naming();
    }

    void FixedUpdate()
    {
        if (networkObject.IsOwner)
        {
            //Set the position and the rotation 
            networkObject.position = transform.position;
            networkObject.rotation = playerModel.transform.rotation;
        }
        else //Non owner, meaning a remote player
        {
            //Receive all NCW fields and use them
            transform.position = networkObject.position;
            playerModel.transform.rotation = networkObject.rotation;
        }
    }

    public override void SetupPlayer(RpcArgs args)
    {
        string receivedPlayerName = args.GetNext<string>();
        playerName = receivedPlayerName;
        nameUI.text = receivedPlayerName;
    }
}
