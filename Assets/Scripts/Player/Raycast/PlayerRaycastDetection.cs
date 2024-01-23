using System;
using UnityEngine;

public class PlayerRaycastDetection : MonoBehaviour
{
    [SerializeField] private Transform capsuleCastGround;
    
    [SerializeField] private Vector2 capsuleSizeGround = new Vector2(1f, 0.1f);

    [SerializeField] private float capsuleAngle = 0f;
    [SerializeField] private float distanceToDetectFloor = 0f;

    [SerializeField] private LayerMask layerGround;

    public bool isGrounded;
    
    private RaycastHit2D capsuleCastGroundHit;

    private void Update()
    {
        SetRaycast();
        SetBool(); 
    }

    private void SetRaycast()
    {
        capsuleCastGroundHit = Physics2D.CapsuleCast(capsuleCastGround.position, capsuleSizeGround, CapsuleDirection2D.Horizontal,
            capsuleAngle, Vector2.down, distanceToDetectFloor, layerGround);
    }
    
    private void SetBool()
    {
        isGrounded = capsuleCastGroundHit;
    }
}
