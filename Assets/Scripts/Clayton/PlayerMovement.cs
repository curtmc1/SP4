using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public float tempSpeed = 1;
    public float mouseSensitivity = 100f;
    public float playerHealth = 100f;
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private float jumpForce = 4f;
    [SerializeField] private float raycastDistance = 1.15f;
    private bool doubleJumped = false;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        tempSpeed = speed;

        //PlayerPrefs, store health and use throughout the game
        PlayerPrefs.SetFloat("playerHealth", playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move() //Movement
    {
        //Shift to increase speed
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
            speed *= 2;

        if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.LeftShift))
            speed = tempSpeed;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z) * speed * Time.deltaTime;

        Vector3 newPosition = playerBody.position + playerBody.transform.TransformDirection(movement);
        playerBody.MovePosition(newPosition);
    }

    private void Jump()
    {
        //If player is on ground, can jump, if on air can jump one more time
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                doubleJumped = false;
                playerBody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
            else
            {
                if (!doubleJumped)
                {
                    playerBody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                    doubleJumped = true;
                }
            }
        }  
    }

    private bool IsGrounded()
    {
        //Use Raycast to check the distance between player and the ground
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance);
    }
}
