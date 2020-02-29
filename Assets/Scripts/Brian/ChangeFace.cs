using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;

public class ChangeFace : ChangeFaceBehavior
{
    EnemyStates states;

    private Transform childObj;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponentInParent<EnemyStates>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!NetworkManager.Instance.IsServer) return; //Server control

        if (states.currState == States.state_roam)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);

            networkObject.SendRpc(RPC_SEND_CHANGE_FACE, Receivers.AllBuffered, true, false);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            networkObject.SendRpc(RPC_SEND_CHANGE_FACE, Receivers.AllBuffered, false, true);
        }

        transform.position = transform.parent.position + new Vector3(0f, 1.125f, 0f);
    }

    public override void SendChangeFace(RpcArgs args)
    {
        if (NetworkManager.Instance.IsServer) return;  //This is for client only

        bool childZero = args.GetNext<bool>();
        bool childOne = args.GetNext<bool>();

        gameObject.transform.GetChild(0).gameObject.SetActive(childZero);
        gameObject.transform.GetChild(1).gameObject.SetActive(childOne);
    }
}
