using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRigidBody2D = collision.GetComponent<Rigidbody2D>();
            if (playerRigidBody2D != null)
            {
                playerRigidBody2D.velocity = new Vector2(playerRigidBody2D.velocity.x, 0f); // Réinitialise la vélocité en Y
                playerRigidBody2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse); // Applique une force de rebondissement
            }
        }
    }
}
