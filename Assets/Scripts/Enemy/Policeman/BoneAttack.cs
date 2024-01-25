using UnityEngine;

public class BoneAttack : MonoBehaviour
{
    private DeathPlayer _deathPlayer;

    private void Awake()
    {
        _deathPlayer = FindObjectOfType<DeathPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _deathPlayer.OnDeath();
        }
    }
}
