using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerCameraView : MonoBehaviour
{
    [SerializeField]
    private new Transform camera;

    // Start is called before the first frame update
    private void Start()
    {
        camera = transform.parent.parent.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        //Just to rotate the item (Health pot) properly
        transform.rotation = camera.rotation;
    }
}
