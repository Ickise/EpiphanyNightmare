using UnityEngine;

public class PassivEnemy : MonoBehaviour
{
    [SerializeField] private GameObject policemanSpawner;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            policemanSpawner.SetActive(true);
        }
    }
}
