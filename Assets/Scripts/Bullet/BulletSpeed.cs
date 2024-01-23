using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float timeToDestoy = 5f;

    private Rigidbody2D bulletRigidbody2D;

    private bool lookAtOriginalXPosition;

    private void Awake()
    {
        bulletRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        
        lookAtOriginalXPosition = InputReader._instance.direction.x >= 0;
        
        Destroy(gameObject, timeToDestoy);
    }

    private void FixedUpdate()
    {
        bulletRigidbody2D.velocity = lookAtOriginalXPosition ? transform.right * bulletSpeed : transform.right * -bulletSpeed;
    }
}