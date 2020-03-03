using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;

public class PlayerArm : PlayerArmBehavior
{
    [SerializeField] private new Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = transform.parent.parent.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (networkObject.IsOwner)
        {
            transform.rotation = new Quaternion(transform.rotation.x, camera.rotation.y, transform.rotation.z, transform.rotation.w);

            networkObject.position = transform.position;
            networkObject.rotation = transform.rotation;
        }
        else
        {
            transform.position = networkObject.position;
            transform.rotation = networkObject.rotation;
        }
    }
}
