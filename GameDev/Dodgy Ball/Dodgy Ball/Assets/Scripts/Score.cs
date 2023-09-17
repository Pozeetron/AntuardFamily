using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text maxScoreText;
    [SerializeField] private Manager manager;
    public int score;
    private int _scoreToChange;
    private int _maxScore;
    void Start()
    {
        _scoreToChange = 5;
        _maxScore = PlayerPrefs.GetInt("maxScore", 0);
        score = 0;
        scoreText.text = score.ToString();
        maxScoreText.text = _maxScore.ToString();
    }

    public void IncreaseScore()
    {
        score++;

        if (score > _maxScore)
        {
            _maxScore = score;
            PlayerPrefs.SetInt("maxScore", _maxScore);
        }

        scoreText.text = score.ToString();
        maxScoreText.text = _maxScore.ToString();

        if (score >= _scoreToChange)
        {
            manager.ChangeObstacle();
            _scoreToChange += 5;
        }
    }
}
