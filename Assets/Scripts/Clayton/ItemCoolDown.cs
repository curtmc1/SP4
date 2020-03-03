using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCoolDown : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 5;
    bool isCooldown;
    Slot slot;
    public bool canCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        slot = gameObject.GetComponentInChildren<Slot>();
        canCoolDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canCoolDown)
        {
            if (slot.gotUse && !isCooldown) //If number is pressd and Item is used
                isCooldown = true;
        }

        if (isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;

            if (imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0;
                slot.gotUse = false;
                canCoolDown = false;
                isCooldown = false;
            }
        }
    }
}
