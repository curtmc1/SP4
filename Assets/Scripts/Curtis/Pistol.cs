using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;
    private bool canShoot;
    public bool hasShot;

    public bool GetCanShoot
    {
        get { return canShoot; }
        set { canShoot = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        hasShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot) return;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bul = Instantiate(bullet, transform.position, transform.rotation);
            bul.GetComponent<Rigidbody>().velocity = transform.forward * 30;
            hasShot = true;
        }
        else 
            hasShot = false;
    }
}
