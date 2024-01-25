using UnityEngine;

public class PassivEnemy : MonoBehaviour
{
    [SerializeField] private GameObject policemanSpawner;

    [SerializeField] private AudioClip deathPassivEnemy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            AudioManager._instance.PlaySFX(deathPassivEnemy);
            policemanSpawner.SetActive(true);
        }
    }
}
