using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] private float groundDrag;
    public Transform orientation;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    
    [Header("Jump")]
    [SerializeField] private float jumpForce = 20.0f;

    [SerializeField] private bool readyToJump;

    [SerializeField] private float jumpCooldown = 0.25f;
    
    private Rigidbody rb;

    [Header("Ground Check")] 
    public Transform groundCheck; // Feet of the player
    public float groundDistance = 0.4f;
    public LayerMask whatIsGround;
    private bool grounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        readyToJump = true;
    }

    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);
        
        GetInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
        
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            Jump();
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Acceleration);
        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
    }

    private void Jump()
    {
        readyToJump = false;
        StartCoroutine(JumpCooldown());
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        readyToJump = true;
    }
}
