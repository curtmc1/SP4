using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private float lookSensitivity = 2f;
    [SerializeField] private float smoothing = 2f;
    private GameObject player;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPos;

    private void Start()
    {
        player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false; might use if have inventory
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        //Mouse X and Mouse Y (It is the default naming) can be found in Project settings -> Input
        Vector2 inputValue = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //Scaling input down
        inputValue = Vector2.Scale(inputValue, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));

        //Smoothing the motion. 
        //Little optimisation: storing it as it is needed in every frame. Dont want to keep resetting it and getting a new one every frame
        //Smoothing is like GetAxis instead of GetAxisRaw. I used smoothing as I can adjust the amount of smoothness I want the motion to be
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputValue.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputValue.y, 1f / smoothing);

        //Take current vector pos and add a new one
        currentLookingPos += smoothedVelocity;
        currentLookingPos.y = Mathf.Clamp(currentLookingPos.y, -60f, 60f);

        transform.localRotation = Quaternion.AngleAxis(-currentLookingPos.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(currentLookingPos.x, player.transform.up);
    }
}
