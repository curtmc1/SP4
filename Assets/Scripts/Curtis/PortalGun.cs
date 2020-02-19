using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shoot");
            //GameObject bul = Instantiate(bullet, transform.position + 2 * transform.forward, transform.rotation);
            //bul.GetComponent<Rigidbody>().velocity = transform.forward * 30;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Wall")
                {
                    Debug.Log("Hit");
                    GameObject p1 = GameObject.FindGameObjectWithTag("Portal1");
                    Destroy(p1);
                    Instantiate(portal1, hit.transform.position + 2 * hit.transform.forward, hit.transform.rotation);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Shoot");
            //GameObject bul = Instantiate(bullet, transform.position + 2 * transform.forward, transform.rotation);
            //bul.GetComponent<Rigidbody>().velocity = transform.forward * 30;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Wall")
                {
                    Debug.Log("Hit");
                    GameObject p2 = GameObject.FindGameObjectWithTag("Portal2");
                    Destroy(p2);
                    Instantiate(portal2, hit.transform.position + 2 * hit.transform.forward, hit.transform.rotation);
                }
            }
        }
    }
}
