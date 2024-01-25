using UnityEngine;

public class ImpactSomething : MonoBehaviour
{
    [SerializeField] private Score _score;

    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private ParticleSystem _particles2;

    [SerializeField] private AudioClip policemanDeath;
    
    private ParticleSystem _bloodParticlesInstance;
    private ParticleSystem _toxicParticlesInstance;
    
    private void Awake()
    {
        _score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("IA") || other.gameObject.CompareTag("IADontCollide"))
        {
            _score.scoreCounter += 10;

            SpawnParticles();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag(("IA")))
        {
            AudioManager._instance.PlaySFX(policemanDeath);
        }
    }

    private void SpawnParticles()
    {
        _bloodParticlesInstance = Instantiate(_particles, transform.position, Quaternion.identity);
        _toxicParticlesInstance = Instantiate(_particles2, transform.position, Quaternion.identity);
    }
}