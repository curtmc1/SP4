using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "First person player")
        {
        }
    }
}
