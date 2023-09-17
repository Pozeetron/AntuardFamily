using System;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteScreen;
    [SerializeField] private GameObject gameOverScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);
        levelCompleteScreen.SetActive(false);
    }

    void FinishLevel()
    {
        levelCompleteScreen.SetActive(true);
    }

    void LevelFailed()
    {
        gameOverScreen.SetActive(true);
    }
}
