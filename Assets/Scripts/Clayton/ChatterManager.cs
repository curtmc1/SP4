using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatterManager : ChatterManagerBehavior
{
    public Transform chatContent; //chat ui transform
    public GameObject chatMessage; //Message prefab

    private string nameToSend;

    public string msg;
    public string MSG 
    { 
        get { return msg; } 
        set { msg = value; } 
    }

    public ScrollRect fields;

    public void writeMessage(InputField sender)
    {
        if (networkObject.IsServer)
        {
            if (string.IsNullOrEmpty(PlayerPrefs.GetString("PlayerName1")))
                nameToSend = "Player 1";
            else
                nameToSend = PlayerPrefs.GetString("PlayerName1"); //Since player 1 is always the be host/ server
        }
        else
        {
            if (string.IsNullOrEmpty(PlayerPrefs.GetString("PlayerName2")))
                nameToSend = "Player 2";
            else
                nameToSend = PlayerPrefs.GetString("PlayerName2");
        }

        if (!string.IsNullOrEmpty(sender.text) && sender.text.Trim().Length > 0)
        {
            sender.text = sender.text.Replace("\r", string.Empty).Replace("\n", string.Empty);
            networkObject.SendRpc(RPC_TRANSMIT_MESSAGE, Receivers.All, nameToSend, sender.text.Trim());

            //Remove the text in the inputField
            sender.text = string.Empty;
            sender.ActivateInputField();
        }
    }

    public override void TransmitMessage(RpcArgs args)
    {
        string username = args.GetNext<string>();
        string message = args.GetNext<string>();

        //If message is empty so do not display it to anyone
        if (string.IsNullOrEmpty(message))
            return;

        GameObject newMessage = Instantiate(chatMessage, chatContent);
        Text content = newMessage.GetComponent<Text>();

        content.text = string.Format(content.text, username, message);
        MSG = string.Format(content.text, username, message);
    }
}
