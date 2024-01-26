using UnityEngine;

public class TriggerToEnd : MonoBehaviour
{
    [SerializeField] private DeathPlayer _deathPlayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _deathPlayer.OnDeath();
        }
    }
}
