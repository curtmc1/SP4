using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour // VIOR not viour
{
    public float speed;
    public float tempSpeed;
    public float mouseSensitivity;
    public float playerHealth;
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private float jumpForce;
    [SerializeField] private float raycastDistance;
    public ParticleSystem jumpEffect;
    private bool doubleJumped = false;
    public ParticleSystem speedParticle;
    int recoilForce;
    WeaponManager weaponManager;
    PortalUI portUI;

    private void Awake()
    {
        speed = 5;
        tempSpeed = 5;
        mouseSensitivity = 100f;
        playerHealth = 100f;
        jumpForce = 4f;
        raycastDistance = 2f;
        doubleJumped = false;

        playerBody = GetComponent<Rigidbody>();
        tempSpeed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("playerHealth", playerHealth);
        speedParticle.gameObject.SetActive(false);
        recoilForce = 80;
        weaponManager = GetComponentInChildren<WeaponManager>();
        portUI = GetComponentInChildren<PortalUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        //Shift to increase speed when walking
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                speedParticle.gameObject.SetActive(true);
                speed *= 2;
            }
            if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = tempSpeed;
                speedParticle.gameObject.SetActive(false);
            }
        }
        else
        {
            speed = tempSpeed;
            speedParticle.gameObject.SetActive(false);
        }

        if (weaponManager.CurrentWeaponChoice == 1) //Add recoil when player shoot using pistol
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (portUI.ammo > 0)
                    playerBody.AddForce(transform.forward * -recoilForce);
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move() //Movement
    {
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
                Vector3 temp = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
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
