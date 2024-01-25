using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 10f;

    [SerializeField] private CharacterController2D characterController2D;

    private bool isPlayerOnTrampoline = false;

    private void FixedUpdate()
    {
        if (isPlayerOnTrampoline)
        {
            DoBounce();
        }
    }
    
    private void DoBounce()
    {
        characterController2D.playerVelocity = new Vector2(characterController2D.playerVelocity.x, bounceForce * Vector2.up.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOnTrampoline = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        isPlayerOnTrampoline = false;
    }
}