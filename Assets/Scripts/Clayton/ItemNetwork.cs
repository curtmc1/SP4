using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;

public class ItemNetwork : HealthPotBehavior
{
    private HealthPot healthPot;
    Slot slot;
    ItemCoolDown iCD;
    public ParticleSystem heal;
    bool gotUseOnce;
    bool disableOnce;

    // Start is called before the first frame update
    void Start()
    {
        slot = gameObject.transform.parent.GetComponentInChildren<Slot>();
        iCD = gameObject.transform.parent.GetComponentInChildren<ItemCoolDown>();
        gotUseOnce = disableOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (networkObject.IsOwner)
        {
            networkObject.position = transform.GetChild(0).gameObject.transform.position;
            networkObject.rotation = transform.GetChild(0).gameObject.transform.rotation;
            networkObject.gotUse = slot.gotUse;
            networkObject.canDisable = iCD.canCoolDown;

            if (slot.gotUse)
                healthPot = GetComponentInChildren<HealthPot>();
        }
        else
        {
            transform.GetChild(0).gameObject.transform.position = networkObject.position;
            transform.GetChild(0).gameObject.transform.rotation = networkObject.rotation;
            slot.gotUse = networkObject.gotUse;

            if (!slot.gotUse)
            {
                gotUseOnce = false;
                disableOnce = false;
            }

            if (slot.gotUse && !gotUseOnce)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                gotUseOnce = true;
            }

            if (networkObject.canDisable && !disableOnce)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                Destroy(Instantiate(heal.gameObject, transform.parent.parent.position, heal.gameObject.transform.rotation) as GameObject, 0.5f);
                disableOnce = true;
            }
        }
    }
}
