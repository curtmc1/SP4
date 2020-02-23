using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine.Events;

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
    private bool shootOncePis;
    private bool shootOncePor1;
    private bool shootOncePor2;

    protected override void NetworkStart()
    {
        base.NetworkStart();
        ownerScripts.Invoke(networkObject.IsOwner);

        weaponManager = GetComponentInChildren<WeaponManager>();

        if (!networkObject.IsOwner)
        {
            weaponManager.GetCanScroll = false;
        }
        else if (networkObject.IsOwner)
        {
            weaponManager.GetCanScroll = true;
        }
    }

    private void Start()
    {
        shootOncePis = assignOwnerPis = assignClientPis = assignOwnerPor = assignClientPor = shootOncePor1 = shootOncePor2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (networkObject.IsOwner)
        {
            networkObject.position = transform.position;
            networkObject.rotation = transform.rotation;
            networkObject.gunChoice = weaponManager.CurrentWeaponChoice;

            if (weaponManager.GetWeapon().activeSelf)
            {
                if (weaponManager.CurrentWeaponChoice == 0)
                {
                    assignOwnerPor = true;

                    if (assignOwnerPor)
                    {
                        portalGun = GetComponentInChildren<PortalGun>();
                        portalGun.GetCanShoot = true;
                        assignOwnerPor = false;
                    }

                    networkObject.p1HasShot = portalGun.p1HasShot;
                    networkObject.p2HasShot = portalGun.p2HasShot;

                    if (portalGun.p1HasShot || portalGun.p2HasShot)
                    {
                        networkObject.portPosition = portalGun.portPos;
                        networkObject.portRotation = portalGun.portRotation;
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
                    networkObject.hasShot = pistol.hasShot;
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

                    if (assignClientPor)
                    {
                        portalGun = GetComponentInChildren<PortalGun>();
                        portalGun.GetCanShoot = false;
                        assignClientPor = false;
                    }
                    portalGun.p1HasShot = networkObject.p1HasShot;
                    portalGun.p2HasShot = networkObject.p2HasShot;

                    //#region ClientPortalInstantiation
                    //if (portalGun.p1HasShot && !shootOncePor1)
                    //{
                    //    GameObject parti1 = Instantiate(portalParticle, portalGun.transform.position + 0.5f * portalGun.transform.forward, portalGun.transform.rotation);
                    //    GameObject p1 = GameObject.FindGameObjectWithTag("Portal1");
                    //    Destroy(p1);
                    //    GameObject bul2 = Instantiate(portal1, networkObject.portPosition, networkObject.portRotation);
                    //    Debug.Log("portal1 pos: " + networkObject.portPosition + " port Roatation " + networkObject.portRotation);
                    //    shootOncePor1 = true;
                    //}
                    //else if (!portalGun.p1HasShot && shootOncePor1)
                    //    shootOncePor1 = false;

                    //if (portalGun.p2HasShot && !shootOncePor2)
                    //{
                    //    GameObject parti2 = Instantiate(portalParticle2, portalGun.transform.position + 0.5f * portalGun.transform.forward, portalGun.transform.rotation);
                    //    GameObject p2 = GameObject.FindGameObjectWithTag("Portal2");
                    //    Destroy(p2);
                    //    GameObject bul3 = Instantiate(portal2, networkObject.portPosition, networkObject.portRotation);
                    //    Debug.Log("portal2 pos: " + networkObject.portPosition + " port Roatation " + networkObject.portRotation);
                    //    shootOncePor2 = true;
                    //}
                    //else if (!portalGun.p2HasShot && shootOncePor2)
                    //    shootOncePor2 = false;
                    //#endregion

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
                    pistol.hasShot = networkObject.hasShot;

                    #region ClientBulletInstantiation
                    if (pistol.hasShot && !shootOncePis)
                    {
                        GameObject bul = Instantiate(bullet, pistol.transform.position, pistol.transform.rotation);
                        bul.GetComponent<Rigidbody>().velocity = transform.forward * 30;
                        shootOncePis = true;
                    }
                    else if (!pistol.hasShot && shootOncePis)
                        shootOncePis = false;
                    #endregion

                }
            }
        }
    }
}