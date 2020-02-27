using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;

public class Pistol : GunBehavior
{
    public GameObject bullet;
    private bool canShoot;

    private float timer;
    private int ammo;
    PortalUI portUI;
    Vector3 vel;

    public bool GetCanShoot
    {
        get { return canShoot; }
        set { canShoot = value; }
    }

    public int Ammo
    {
        get { return ammo; }
        set { ammo = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        ammo = 30;
        portUI = gameObject.transform.parent.parent.parent.GetComponentInChildren<PortalUI>();
    }

    // Update is called once per frame
    void Update()
    {
       if (!networkObject.IsOwner) return;

        timer += Time.deltaTime;
        if (!canShoot) return;

        portUI.ammo = Ammo;

        if (Input.GetMouseButtonDown(0) && timer > 0.5f && ammo > 0)
        {
            SoundManager.PlaySound("pistolsound");
            GameObject bul = Instantiate(bullet, transform.position, transform.rotation);
            bul.GetComponent<Rigidbody>().velocity = transform.forward * 30;
            vel = transform.forward * 30;
            networkObject.SendRpc(RPC_SHOOT, Receivers.AllBuffered, transform.position, transform.rotation, vel);

            ammo--;
            timer = 0.0f;
        }
    }

    public override void Shoot(RpcArgs args)
    {
        if (networkObject.IsOwner) return;

        Vector3 pos = args.GetNext<Vector3>();
        Quaternion rot = args.GetNext<Quaternion>();
        Vector3 forward = args.GetNext<Vector3>();

        GameObject bul = Instantiate(bullet, pos, rot);
        bul.GetComponent<Rigidbody>().velocity = forward;
    }
}
