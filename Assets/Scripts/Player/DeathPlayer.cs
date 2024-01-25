using TMPro;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] listToEnable;
    
    [SerializeField] private GameObject[] listToDisable;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private Transform newPositionScoreText;

    public void OnDeath()
    {
        foreach (var gameObject in listToEnable)
        {
            gameObject.SetActive(true);
        }

        foreach (var gameObject in listToDisable)
        {
            gameObject.SetActive(false);
        }

        scoreText.gameObject.transform.position = newPositionScoreText.position;
    }
}