using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;

public class EnemyLaser : EnemyLaserBehavior
{
    public GameObject laser;
    private float cooldown = 2f;
    private float laserspeed = 50f;

    EnemyStates states;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponent<EnemyStates>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!NetworkManager.Instance.IsServer) return; //Server control

        cooldown -= Time.deltaTime;

        if (states.currState == States.state_shoot)
        {
            if (cooldown <= 0f)
            {
                GameObject las = Instantiate(laser, transform.GetChild(4).position, transform.rotation);
                las.GetComponent<Rigidbody>().velocity = transform.forward * laserspeed;

                Vector3 tempForward = transform.forward * laserspeed;

                networkObject.SendRpc(RPC_SHOOT_LASER, Receivers.AllBuffered, transform.GetChild(4).position, transform.rotation, tempForward);

                cooldown = 2f;
            }
        }
    }

    public override void ShootLaser(RpcArgs args)
    {
        if (NetworkManager.Instance.IsServer) return;  //This is for client only

        Vector3 pos = args.GetNext<Vector3>();
        Quaternion rot = args.GetNext<Quaternion>();
        Vector3 forward = args.GetNext<Vector3>();

        GameObject las = Instantiate(laser, pos, rot);
        las.GetComponent<Rigidbody>().velocity = forward;
    }
}
