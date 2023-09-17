using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int coins;

    [SerializeField] private Text coinsText;
    [SerializeField] private Image[] balls;
    [SerializeField] private Sprite[] unlockedBalls;
    [SerializeField] private Sprite lockedBall;

    private List<int> colors = new List<int>() { 1, 0, 0, 0, 0, 0 };

    public int selectedBall;
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");

        selectedBall = PlayerPrefs.GetInt("selectedBall", 0);

        colors[0] = PlayerPrefs.GetInt("orange", 1);
        colors[1] = PlayerPrefs.GetInt("red", 0);
        colors[2] = PlayerPrefs.GetInt("blue", 0);
        colors[3] = PlayerPrefs.GetInt("lightBlue", 0);
        colors[4] = PlayerPrefs.GetInt("purple", 0);
        colors[5] = PlayerPrefs.GetInt("green", 0);
        
        PlayerPrefs.SetInt("coins", coins);
        
        PlayerPrefs.SetInt("selectedBall", selectedBall);
        
        PlayerPrefs.SetInt("orange", colors[0]);
        PlayerPrefs.SetInt("red", colors[1]);
        PlayerPrefs.SetInt("blue", colors[2]);
        PlayerPrefs.SetInt("lightBlue", colors[3]);
        PlayerPrefs.SetInt("purple", colors[4]);
        PlayerPrefs.SetInt("green", colors[5]);

        UpdateUI();
    }

    public void OpenBall(int id)
    {
        string color = id == 0 ? "orange" : id == 1 ? "red" : id == 2 ? "green" : id == 3 ? "blue" : id == 4 ? "lightBlue" : id == 5 ? "purple" : String.Empty;

        if (PlayerPrefs.GetInt(color) == 0)
        {
            if (coins >= 50)
            {
                coins -= 50;
                PlayerPrefs.SetInt("coins", coins);

                colors[id] = 1;

                selectedBall = id;
                PlayerPrefs.SetInt("selectedBall", selectedBall);
            
                PlayerPrefs.SetInt(color, 1);
            }
            else
            {
                colors[id] = 0;
                PlayerPrefs.SetInt(color, 0);
                Debug.Log("No Money");
            }
        }
        else
        {
            selectedBall = id;
            PlayerPrefs.SetInt("selectedBall", selectedBall);
            Debug.Log("Already Has");
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        coinsText.text = coins.ToString();
        
        for (int i = 0; i < colors.Count; i++)
        {
            balls[i].sprite = colors[i] == 1 ? unlockedBalls[i] : lockedBall;
        }
    }
}
