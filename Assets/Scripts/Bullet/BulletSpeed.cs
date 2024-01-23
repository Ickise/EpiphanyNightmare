using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float timeToDestroy = 2f;
   
    private GameObject playerVisual;

    private Rigidbody2D bulletRigidbody2D;

    private bool lookAtOriginalYRotation;

    private void Awake()
    {
        playerVisual = FindObjectOfType<SpriteFlip>().gameObject;
        
        bulletRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        
        lookAtOriginalYRotation = playerVisual.transform.rotation.y == 0;
        
        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {
        BulletDirection();
    }

    private void BulletDirection()
    {
        bulletRigidbody2D.velocity = lookAtOriginalYRotation ? transform.right * bulletSpeed : transform.right * -bulletSpeed;
    }
}