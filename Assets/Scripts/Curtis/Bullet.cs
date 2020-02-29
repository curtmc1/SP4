using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string naming;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
    }
}
