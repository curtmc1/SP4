using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    private WeaponManager gun;
    void Start()
    {
        gun = (WeaponManager)FindObjectOfType(typeof(WeaponManager));
    }

    private void Update()
    {
        //gun = (WeaponManager)FindObjectOfType(typeof(WeaponManager));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SoundManager.PlaySound("ammopickupsound");
            gun.ammoScore += 10;
            Destroy(this.gameObject);
            Debug.Log(gun.ammoScore);
        }
    }
}
