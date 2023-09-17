using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{ 
    private static int unlockedLevels = 1;

    [SerializeField] private Sprite[] levelsNumber;
    [SerializeField] private Image[] levelsButton;
    [SerializeField] private Sprite lockedLevel;

    private void Start()
    {
        unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);
        ApplyUnlockedLevels();
    }
    
    public static void UnlockNextLevel()
    {
        if (unlockedLevels < SceneManager.sceneCountInBuildSettings - 1)
        {
            unlockedLevels++;
            PlayerPrefs.SetInt("UnlockedLevels", unlockedLevels);
        }
    }

    private void ApplyUnlockedLevels()
    {
        int i = 0;
        for (; i < unlockedLevels; i++)
        {
            levelsButton[i].raycastTarget = true;
            levelsButton[i].sprite = levelsNumber[i];
        }

        for (; i < levelsButton.Length; i++)
        {
            levelsButton[i].raycastTarget = false;
            levelsButton[i].sprite = lockedLevel;
        }
    }
}
