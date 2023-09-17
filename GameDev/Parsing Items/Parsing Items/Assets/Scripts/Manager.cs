using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private Inventory inventory;
    private Timer timer;
    public int deleteCoupleToWin;
    
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject winMenu;

    [SerializeField] private GameObject[] stars;

    private void Start()
    {
        Time.timeScale = 1;
        timer = FindObjectOfType<Timer>();
        inventory = FindObjectOfType<Inventory>();
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(false);
        }
    }

    private void Update()
    {
        
        if (inventory.IsInventoryFull() || !timer.enabled)
        {
            GameOver();
        }
            
        if (inventory.deletedCouple >= deleteCoupleToWin)
        {
            Win();
        }
        
    }

    private void GameOver()
    {
        gameOverMenu.SetActive(true);
        inventory.enabled = false;
        timer.enabled = false;
    }
    
    private void Win()
    {
        for (int i = 0; i < timer.stars; i++)
        {
            stars[i].SetActive(true);
        }
        winMenu.SetActive(true);
        inventory.enabled = false;
        timer.enabled = false;
        LevelManager.UnlockNextLevel();
        this.enabled = false;
    }
}
