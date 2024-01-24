using UnityEngine;

public class ImpactSomething : MonoBehaviour
{
    [SerializeField] private Score _score;

    [SerializeField] private ParticleSystem _bloodParticles;

    private ParticleSystem _bloodParticlesInstance;

    private void Awake()
    {
        _score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("IA"))
        {
            _score.scoreCounter += 10;

            SpawnParticles();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void SpawnParticles()
    {
        _bloodParticlesInstance = Instantiate(_bloodParticles, transform.position, Quaternion.identity);
    }
}