using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRigidBody2D = collision.GetComponent<Rigidbody2D>();

            CharacterController2D characterController2D = collision.GetComponent<CharacterController2D>();
            
            if (playerRigidBody2D != null)
            {
                characterController2D.playerVelocity = new Vector2(characterController2D.playerVelocity.x, 0f);
                characterController2D.playerVelocity.y = bounceForce * Vector2.up.y;
            }
        }
    }
}
