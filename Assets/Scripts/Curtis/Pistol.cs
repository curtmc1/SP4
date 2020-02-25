using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;
    private bool canShoot;
    public bool hasShot;

    private float timer;
    private int ammo;

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
        hasShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!canShoot) return;

        if (Input.GetMouseButtonDown(0) && timer > 0.5f && ammo > 0)
        {
            GameObject bul = Instantiate(bullet, transform.position, transform.rotation);
            bul.GetComponent<Rigidbody>().velocity = transform.forward * 30;
            ammo--;
            timer = 0.0f;
            hasShot = true;
        }
        else 
            hasShot = false;
    }
}
