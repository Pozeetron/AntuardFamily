using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text leaderBordScore;
    private int _bestScore;
    private int _currentScore;
    
    void Start()
    {
        _bestScore = PlayerPrefs.GetInt("bestScore", 0);
        _currentScore = 0;
    }

    public void IncreaseScore()
    {
        _currentScore++;
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
            PlayerPrefs.SetInt("bestScore", _bestScore);
        }
        
        scoreText.text = _currentScore.ToString();
        leaderBordScore.text = _bestScore.ToString();
    }
}
