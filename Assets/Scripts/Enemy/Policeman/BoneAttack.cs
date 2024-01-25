using UnityEngine;

public class BoneAttack : MonoBehaviour
{
    private DeathPlayer _deathPlayer;

    [SerializeField] private AudioClip[] listDeathPlayerSound;

    private void Awake()
    {
        _deathPlayer = FindObjectOfType<DeathPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager._instance.PlayRandomSound(listDeathPlayerSound);
            _deathPlayer.OnDeath();
        }
    }
}
