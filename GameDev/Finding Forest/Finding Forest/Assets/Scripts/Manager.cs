using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int firstRequiredItemId;
    public int secondRequiredItemId;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject gameOverMenu;
    public int requiredClickedItems;
    public int currentClickedItems;

    void Update()
    {
        if (currentClickedItems >= requiredClickedItems)
        {
            Item.canClick = false;
            winMenu.SetActive(true);
            timer.StopTimer();
        }

        if (timer.currentTime <= 0)
        {
            Item.canClick = false;
            gameOverMenu.SetActive(true);
            timer.StopTimer();
        }
    }

    public void ItemClicked(int id)
    {
        if (firstRequiredItemId == id || secondRequiredItemId == id)
        {
            currentClickedItems++;
        }
        else
        {
            if(PlayerPrefs.GetInt("vibrationOn") == 1)
                Handheld.Vibrate();
            timer.ReduceTime();
        }
    }
}
