using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<GameObject> weapons;

    private float scroll;
    private int currWeapon;
    private int prevWeapon;
    private bool canScroll;

    public bool GetCanScroll
    {
        get { return canScroll; }
        set { canScroll = value; }
    }

    public void SetWeapon(int _currentWeapon)
    {
        currWeapon = _currentWeapon;

        if (currWeapon != prevWeapon)
        {
            foreach (GameObject weapon in weapons)
            {
                weapon.SetActive(false);
            }
            weapons[_currentWeapon].SetActive(true);
        }
    }

    public GameObject GetWeapon()
    {
        return weapons[currWeapon];
    }

    public int CurrentWeaponChoice
    {
        get { return currWeapon; }
        set { currWeapon = value; }
    }

    [SerializeField]
    private new Transform camera;

    private void Start()
    {
        camera = transform.parent.parent.GetChild(0);
        for(int i = 0; i < transform.childCount; ++i)
        {
            weapons.Add(transform.GetChild(i).gameObject);
        }

        currWeapon = 0;
        //weapons[0].SetActive(true);
        //weapons[1].SetActive(false);
    }

     void Update()
    {
        transform.rotation = camera.rotation;

        if (canScroll)
        {
            scroll = Input.GetAxis("Mouse ScrollWheel") / 0.1f;

            if (Input.GetKeyDown("1"))
            {
                currWeapon = 0;
            }
            if (Input.GetKeyDown("2"))
            {
                currWeapon = 1;
            }
        }

        prevWeapon = currWeapon;
        currWeapon += (int)scroll;

        if (currWeapon < 0)
        {
            currWeapon = weapons.Count - 1;
        }
        if (currWeapon > weapons.Count - 1)
        {
            currWeapon = 0;
        }

        SetWeapon(currWeapon);


        //switch (currWeapon)
        //{
        //    case 0:
        //        weapons[0].SetActive(true);
        //        weapons[1].SetActive(false);
        //        break;
        //    case 1:
        //        weapons[1].SetActive(true);
        //        weapons[0].SetActive(false);
        //        break;
        //}
    }
}
