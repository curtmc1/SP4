﻿using System.Collections;
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
        lookSensitivity = PlayerPrefs.GetFloat("LookSensitivity");
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
        //Smoothing is like GetAxis instead of GetAxisRaw. Used smoothing as I can adjust the amount of smoothness I want the motion to be
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputValue.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputValue.y, 1f / smoothing);

        //Take current vector pos and add a new one
        currentLookingPos += smoothedVelocity * Time.deltaTime;
        currentLookingPos.y = Mathf.Clamp(currentLookingPos.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-currentLookingPos.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(currentLookingPos.x, player.transform.up);
    }
}
