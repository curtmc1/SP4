using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shoot");
            GameObject bul = Instantiate(bullet, transform.position, transform.rotation);
            bul.GetComponent<Rigidbody>().velocity = transform.forward * 30;
        }
    }
}
