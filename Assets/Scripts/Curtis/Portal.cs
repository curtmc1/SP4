using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;

    private const float MAX_VEL = 20.0f;
    private const float MIN_VEL = -20.0f;

    // Update is called once per frame
    void Update()
    {
        if (!portal1)
        {
            portal1 = GameObject.Find("portal");
        }
        if (!portal2)
        {
            portal2 = GameObject.Find("portal2");
        }
        //Debug.Log("HELLOOOOO?");
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collided");
        Debug.Log(col.gameObject.name);

        if (portal1 && portal2)
        {
            Debug.Log("Both Portals Exist");

            if (gameObject == portal1)
            {
                Debug.Log("Portal 1");
                col.transform.position = portal2.transform.position + portal2.transform.forward * 3;
                col.attachedRigidbody.velocity = portal2.transform.forward * col.attachedRigidbody.velocity.magnitude;

                if (col.attachedRigidbody.velocity.x > MAX_VEL)
                {
                    Debug.Log("MAX VEL REACHED X");
                    col.attachedRigidbody.velocity = new Vector3(MAX_VEL, 0, 0);
                }
                if (col.attachedRigidbody.velocity.y > MAX_VEL)
                {
                    Debug.Log("MAX VEL REACHED Y");
                    col.attachedRigidbody.velocity = new Vector3(0, MAX_VEL, 0);
                }
                if (col.attachedRigidbody.velocity.z > MAX_VEL)
                {
                    Debug.Log("MAX VEL REACHED Z");
                    col.attachedRigidbody.velocity = new Vector3(0, 0, MAX_VEL);
                }

                if (col.attachedRigidbody.velocity.x < MIN_VEL)
                {
                    Debug.Log("MIN VEL REACHED X");
                    col.attachedRigidbody.velocity = new Vector3(MIN_VEL, 0, 0);
                }
                if (col.attachedRigidbody.velocity.y < MIN_VEL)
                {
                    Debug.Log("MIN VEL REACHED Y");
                    col.attachedRigidbody.velocity = new Vector3(0, MIN_VEL, 0);
                }
                if (col.attachedRigidbody.velocity.z < MIN_VEL)
                {
                    Debug.Log("MIN VEL REACHED Z");
                    col.attachedRigidbody.velocity = new Vector3(0, 0, MIN_VEL);
                }
            }

            if (gameObject == portal2)
            {
                Debug.Log("Portal 2");
                col.transform.position = portal1.transform.position + portal1.transform.forward * 3;
                col.attachedRigidbody.velocity = portal1.transform.forward * col.attachedRigidbody.velocity.magnitude;

                if (col.attachedRigidbody.velocity.x > MAX_VEL)
                {
                    Debug.Log("MAX VEL REACHED X");
                    col.attachedRigidbody.velocity = new Vector3(MAX_VEL, 0, 0);
                }
                if (col.attachedRigidbody.velocity.y > MAX_VEL)
                {
                    Debug.Log("MAX VEL REACHED Y");
                    col.attachedRigidbody.velocity = new Vector3(0, MAX_VEL, 0);
                }
                if (col.attachedRigidbody.velocity.z > MAX_VEL)
                {
                    Debug.Log("MAX VEL REACHED Z");
                    col.attachedRigidbody.velocity = new Vector3(0, 0, MAX_VEL);
                }

                if (col.attachedRigidbody.velocity.x < MIN_VEL)
                {
                    Debug.Log("MIN VEL REACHED X");
                    col.attachedRigidbody.velocity = new Vector3(MIN_VEL, 0, 0);
                }
                if (col.attachedRigidbody.velocity.y < MIN_VEL)
                {
                    Debug.Log("MIN VEL REACHED Y");
                    col.attachedRigidbody.velocity = new Vector3(0, MIN_VEL, 0);
                }
                if (col.attachedRigidbody.velocity.z < MIN_VEL)
                {
                    Debug.Log("MIN VEL REACHED Z");
                    col.attachedRigidbody.velocity = new Vector3(0, 0, MIN_VEL);
                }
            }
        }
    }

    private void OnTriggerStay(Collider col)
    {
        Debug.Log("Collided");
        Debug.Log(col.gameObject.name);

        if (portal1 && portal2)
        {
            Debug.Log("Both Portals Exist");

            if (gameObject == portal1)
            {
                Debug.Log("Portal 1");
                col.transform.position = portal2.transform.position + portal2.transform.forward * 3;
                col.attachedRigidbody.velocity = portal2.transform.forward * col.attachedRigidbody.velocity.magnitude;

                if (col.attachedRigidbody.velocity.x > MAX_VEL)
                {
                    Debug.Log("MAX VEL REACHED X");
                    col.attachedRigidbody.velocity = new Vector3(MAX_VEL, 0, 0);
                }
                if (col.attachedRigidbody.velocity.y > MAX_VEL)
                {
                    Debug.Log("MAX VEL REACHED Y");
                    col.attachedRigidbody.velocity = new Vector3(0, MAX_VEL, 0);
                }
                if (col.attachedRigidbody.velocity.z > MAX_VEL)
                {
                    Debug.Log("MAX VEL REACHED Z");
                    col.attachedRigidbody.velocity = new Vector3(0, 0, MAX_VEL);
                }

                if (col.attachedRigidbody.velocity.x < MIN_VEL)
                {
                    Debug.Log("MIN VEL REACHED X");
                    col.attachedRigidbody.velocity = new Vector3(MIN_VEL, 0, 0);
                }
                if (col.attachedRigidbody.velocity.y < MIN_VEL)
                {
                    Debug.Log("MIN VEL REACHED Y");
                    col.attachedRigidbody.velocity = new Vector3(0, MIN_VEL, 0);
                }
                if (col.attachedRigidbody.velocity.z < MIN_VEL)
                {
                    Debug.Log("MIN VEL REACHED Z");
                    col.attachedRigidbody.velocity = new Vector3(0, 0, MIN_VEL);
                }
            }

            if (gameObject == portal2)
            {
                Debug.Log("Portal 2");
                col.transform.position = portal1.transform.position + portal1.transform.forward * 3;
                col.attachedRigidbody.velocity = portal1.transform.forward * col.attachedRigidbody.velocity.magnitude;

                if (col.attachedRigidbody.velocity.x > MAX_VEL)
                {
                    Debug.Log("MAX VEL REACHED X");
                    col.attachedRigidbody.velocity = new Vector3(MAX_VEL, 0, 0);
                }
                if (col.attachedRigidbody.velocity.y > MAX_VEL)
                {
                    Debug.Log("MAX VEL REACHED Y");
                    col.attachedRigidbody.velocity = new Vector3(0, MAX_VEL, 0);
                }
                if (col.attachedRigidbody.velocity.z > MAX_VEL)
                {
                    Debug.Log("MAX VEL REACHED Z");
                    col.attachedRigidbody.velocity = new Vector3(0, 0, MAX_VEL);
                }

                if (col.attachedRigidbody.velocity.x < MIN_VEL)
                {
                    Debug.Log("MIN VEL REACHED X");
                    col.attachedRigidbody.velocity = new Vector3(MIN_VEL, 0, 0);
                }
                if (col.attachedRigidbody.velocity.y < MIN_VEL)
                {
                    Debug.Log("MIN VEL REACHED Y");
                    col.attachedRigidbody.velocity = new Vector3(0, MIN_VEL, 0);
                }
                if (col.attachedRigidbody.velocity.z < MIN_VEL)
                {
                    Debug.Log("MIN VEL REACHED Z");
                    col.attachedRigidbody.velocity = new Vector3(0, 0, MIN_VEL);
                }
            }
        }
    }
}
