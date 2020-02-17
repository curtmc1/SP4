using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;


    private float rotateX = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotateX -= mouseY;

        //Clamp roatate so that we will not over-rotate till we look behind the player
        rotateX = Mathf.Clamp(rotateX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
