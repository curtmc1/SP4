using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine.Events;
using BeardedManStudios.Forge.Networking;

public class GunNetwork : GunBehavior
{
    [System.Serializable] public class ToggleEvent : UnityEvent<bool> { } //using Unity event
    [SerializeField] ToggleEvent ownerScripts;

    private WeaponManager weaponManager;
    private Pistol pistol;
    private PortalGun portalGun;
    public GameObject bullet;
    public GameObject portal1;
    public GameObject portal2;

    public GameObject portalParticle;
    public GameObject portalParticle2;
    private bool assignOwnerPis;
    private bool assignClientPis;
    private bool assignOwnerPor;
    private bool assignClientPor;

    private void Awake()
    {
        assignOwnerPis = assignClientPis = assignOwnerPor = assignClientPor = false;

        weaponManager = GetComponentInChildren<WeaponManager>();
    }

    protected override void NetworkStart()
    {
        base.NetworkStart();
        ownerScripts.Invoke(networkObject.IsOwner);
            
        if (networkObject.IsOwner) //If owner of the window then can scroll
            weaponManager.GetCanScroll = true;
        else
           weaponManager.GetCanScroll = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (networkObject.IsOwner)
        {
            networkObject.position = transform.position;
            networkObject.rotation = transform.rotation;
            networkObject.gunChoice = weaponManager.CurrentWeaponChoice;

            if (weaponManager.GetWeapon().activeSelf) //If that particular weapon is active
            {
                if (weaponManager.CurrentWeaponChoice == 0) //If weapon is portal
                {
                    assignOwnerPor = true;

                    if (assignOwnerPor) //assgin once
                    {
                        portalGun = GetComponentInChildren<PortalGun>();
                        portalGun.GetCanShoot = true;
                        assignOwnerPor = false;
                    }
                }
                else if (weaponManager.CurrentWeaponChoice == 1)
                {
                    assignOwnerPis = true;

                    if (assignOwnerPis)
                    {
                        pistol = GetComponentInChildren<Pistol>();
                        pistol.GetCanShoot = true;
                        assignOwnerPis = false;
                    }
                }
            }
        }
        else
        {
            transform.position = networkObject.position;
            transform.rotation = networkObject.rotation;
            weaponManager.CurrentWeaponChoice = networkObject.gunChoice;
            weaponManager.SetWeapon(weaponManager.CurrentWeaponChoice);

            if (weaponManager.GetWeapon().activeSelf)
            {
                if (weaponManager.CurrentWeaponChoice == 0)
                {
                    assignClientPor = true;

                    if (assignClientPor) //Assign once
                    {
                        portalGun = GetComponentInChildren<PortalGun>();
                        portalGun.GetCanShoot = false;
                        assignClientPor = false;
                    }
                }
                else if (weaponManager.CurrentWeaponChoice == 1)
                {
                    assignClientPis = true;

                    if (assignClientPis)
                    {
                        pistol = GetComponentInChildren<Pistol>();
                        pistol.GetCanShoot = false;
                        assignClientPis = false;
                    }
                }
            }
        }
    }

    public override void Shoot(RpcArgs args) //Do nothing. Cannot removed because of the GunBehavior it inherited from. It is used in other class
    {
    }

    public override void Object(RpcArgs args)
    {
    }
}