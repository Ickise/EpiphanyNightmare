using UnityEngine;

public class ImpactSomething : MonoBehaviour
{
  [SerializeField] private Score _score;

  private void Awake()
  {
    _score = FindObjectOfType<Score>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("IA"))
    {
      _score.scoreCounter += 10;
      Destroy(other.gameObject);
      Destroy(gameObject);
    }
  }
}
