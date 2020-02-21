using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<GameObject> weapons;
    private float scroll;

    public int currWeapon;

    private void Start()
    {
        for(int i = 0; i < transform.childCount; ++i)
        {
            weapons.Add(transform.GetChild(i).gameObject);
        }

        currWeapon = 0;
        weapons[0].SetActive(true);
        weapons[1].SetActive(false);
    }

    private void Update()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel") / 0.1f;

        if (currWeapon < 0)
        {
            currWeapon = weapons.Count - 1;
        }
        if (currWeapon > weapons.Count - 1)
        {
            currWeapon = 0;
        }

        currWeapon += (int)scroll;

        switch (currWeapon)
        {
            case 0:
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
                break;
            case 1:
                weapons[1].SetActive(true);
                weapons[0].SetActive(false);
                break;
        }


        if (Input.GetKeyDown("1"))
        {
            currWeapon = 0;
        }
        if (Input.GetKeyDown("2"))
        {
            currWeapon = 1;
        }
    }
}
