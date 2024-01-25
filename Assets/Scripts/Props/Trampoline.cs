using System;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 10f;

    [SerializeField] private CharacterController2D characterController2D;

    [SerializeField] private bool doBounce;

    private void FixedUpdate()
    {
        DoBounce();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doBounce = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        doBounce = false;
    }

    private void DoBounce()
    {
        if (doBounce)
        {
            characterController2D.playerVelocity = new Vector2(characterController2D.playerVelocity.x, 0f);
            characterController2D.playerVelocity.y = bounceForce * Vector2.up.y;
        }
    }
}