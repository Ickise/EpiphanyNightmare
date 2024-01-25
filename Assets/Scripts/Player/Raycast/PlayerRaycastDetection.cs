using UnityEngine;
using UnityEngine.Serialization;

public class PlayerRaycastDetection : MonoBehaviour
{
    [SerializeField] private Transform capsuleCastGround;
    [SerializeField] private Transform capsuleCastRight;

    [SerializeField] private Vector2 capsuleSizeGround = new Vector2(1f, 0.1f);
    [SerializeField] private Vector2 capsuleSizeWall = new Vector2(0.1f, 2f);

    [SerializeField] private float capsuleAngle = 0f;
    [SerializeField] private float distanceToDetectFloor = 0f;
    [SerializeField] private float distanceToDetectWall = 0f;

    [SerializeField] private LayerMask layerGround;
    [SerializeField] private LayerMask layerWall;

    public bool isGrounded;
    public bool touchWall;

    private RaycastHit2D capsuleCastGroundHit, capsuleCastWallHit;

    private void Update()
    {
        SetRaycast();
        SetBool();
    }

    private void SetRaycast()
    {
        capsuleCastGroundHit = Physics2D.CapsuleCast(capsuleCastGround.position, capsuleSizeGround,
            CapsuleDirection2D.Horizontal,
            capsuleAngle, Vector2.down, distanceToDetectFloor, layerGround);

        capsuleCastWallHit = Physics2D.CapsuleCast(capsuleCastRight.position, capsuleSizeWall,
            CapsuleDirection2D.Vertical, capsuleAngle, Vector2.right, distanceToDetectWall, layerWall);
    }

    private void SetBool()
    {
        isGrounded = capsuleCastGroundHit;
        touchWall = capsuleCastWallHit;
    }
}