using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = -9.8f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 2.5f;
    public Transform groundCheck;
    public LayerMask groundMask;
    private Vector3 velocity;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Check if player is on ground | create an invisible sphere to check if collide with anything ( If yes then isGrounded will be true)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Might register before player is totally on the ground, so set velocity to a little bit below ground to prevent it
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Fomula for speed travel after falling a height h (With reference of Gravity Potential Energy and Kinetic Energy) | v = square root of -2 * g * h 
        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(-2 * gravity * jumpHeight);

        //Free fall formula | y = half * gravity * time^2
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
