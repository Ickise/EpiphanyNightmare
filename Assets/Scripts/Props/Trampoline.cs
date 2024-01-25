using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 10f;

    [SerializeField] private CharacterController2D characterController2D;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            characterController2D.playerVelocity = new Vector2(characterController2D.playerVelocity.x, 0f);
            characterController2D.playerVelocity.y = bounceForce * Vector2.up.y;
        }
    }
}