using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPot : MonoBehaviour
{
    private HealthBarShrink hpbar;
    Item item;
    ItemCoolDown iCD;
    public bool canDisable;
    public ParticleSystem heal;

    void Start()
    {
        hpbar = (HealthBarShrink)FindObjectOfType(typeof(HealthBarShrink));
        item = GetComponent<Item>();

        iCD = (ItemCoolDown)FindObjectOfType(typeof(ItemCoolDown));
        canDisable = false;
    }

    void Update()
    {
        if (!item.equipped) return;

        if (Input.GetKeyDown(KeyCode.G))
        {
            hpbar.IncreaseHealth(20);
            Destroy(Instantiate(heal.gameObject, transform.parent.parent.parent.position, heal.gameObject.transform.rotation) as GameObject, 0.5f);
            canDisable = true;
            gameObject.SetActive(false);
            iCD.canCoolDown = true;
        }
    }
}
