using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private float timeToIncreaseScore = 2f;
    private float time;

    public int scoreCounter;

    private void Update()
    {
        time += Time.deltaTime;
        
        GainPoint();
        RefreshScoreText();
    }

    private void RefreshScoreText()
    {
        scoreText.text = "Score: " + scoreCounter;
    }

    private void GainPoint()
    {
        if (time >= timeToIncreaseScore)
        {
            time = 0f;
            scoreCounter += 1;
        }
    }
}
