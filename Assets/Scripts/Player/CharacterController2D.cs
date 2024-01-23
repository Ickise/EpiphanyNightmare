using System;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private PlayerRaycastDetection _playerRaycastDetection;

    [SerializeField] private Rigidbody2D playerRigidbody2D;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxHeight = 3f;
    [SerializeField] private float gravityFactor = 2f;
    [SerializeField] private float hangTime = 0.1f;
    [SerializeField] private float fallMultiplier = 3f;
    [SerializeField] private float lowJumpMultiplier = 2.5f;
    
    private float hangTimeCounter;

    private Vector2 playerVelocity;

    private void Start()
    {
        InputReader._instance.onMoveEvent.AddListener(Movement);
        InputReader._instance.onJumpEvent.AddListener(Jump);
    }

    private void Update()
    {
        CoyoteTime();
    }

    private void FixedUpdate()
    {
        SetGravity();
        ComputeGravity();
        
        if (InputReader._instance.direction != Vector2.zero && _playerRaycastDetection.isGrounded)
        {
            playerRigidbody2D.velocity = playerVelocity ;
        }
        else
        {
            playerRigidbody2D.velocity = new Vector2(InputReader._instance.direction.x, playerVelocity.y);
        }

        if (InputReader._instance.jump)
        {
            Jump();
        }
    }

    private void Movement()
    {
        playerVelocity.x += InputReader._instance.direction.x * speed;
    }
    
    private void Jump()
    {
        hangTimeCounter = 0f;
        playerVelocity.y = Mathf.Sqrt(-2 * maxHeight * Physics2D.gravity.y * gravityFactor);
    }
    
    private void CoyoteTime()
    {
        if (_playerRaycastDetection.isGrounded) hangTimeCounter = hangTime;
        else hangTimeCounter -= Time.deltaTime;
    }
    
    private void SetGravity()
    {
        if (_playerRaycastDetection.isGrounded)
        {
            playerVelocity.y = 0;
        }
        else
        {
            playerVelocity.y += Physics2D.gravity.y * Time.deltaTime * gravityFactor;
        }
    }
    
    private void ComputeGravity()
    {
        bool isFalling = playerVelocity.y < 0;
        bool isReleasingJump = playerVelocity.y > 0 && !InputReader._instance.jump;

        if (!isFalling && !isReleasingJump)
        {
            return;
        }

        var factor = isFalling ? fallMultiplier : lowJumpMultiplier;
        playerVelocity += Vector2.up * (Physics2D.gravity.y * (factor - 1) * Time.deltaTime);
    }

}