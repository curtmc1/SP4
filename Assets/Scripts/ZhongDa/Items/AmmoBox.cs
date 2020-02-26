using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    private Pistol gun;
    void Start()
    {
        gun = (Pistol)FindObjectOfType(typeof(Pistol));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gun.Ammo += 10;
            Destroy(this.gameObject);
            Debug.Log(gun.Ammo);
        }
    }
}
