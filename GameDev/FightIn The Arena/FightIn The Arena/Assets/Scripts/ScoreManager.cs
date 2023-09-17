using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int _currentScore = 0;

    public void UpdateScoreUI(int score)
    {
        _currentScore += score;
        scoreText.text = _currentScore.ToString();
    }
}
