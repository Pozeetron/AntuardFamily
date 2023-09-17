using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float countdownTime = 60f; // Начальное время в секундах
    private float currentTime;
    [SerializeField] private Text timerTime;
    [SerializeField] private Image timerImage;
    [SerializeField] private Sprite redTimerSprite;
    public int stars;

    private void Start()
    {
        currentTime = countdownTime; // Инициализация текущего времени
        timerTime.text = currentTime.ToString();
        stars = 3;
        StartTimer();
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Уменьшаем время на прошедшее время кадра
            timerTime.text = currentTime.ToString("F2");
            if (currentTime <= countdownTime / 2)
                stars = 2;
            if (currentTime <= countdownTime / 3)
                stars = 1;
            if (currentTime <= 10)
            {
                timerImage.sprite = redTimerSprite;
                timerTime.color = Color.red;
            }
        }
        else
        {
            Vibrate();
            Debug.Log("Time's up!");
            StopTimer();
        }
    }

    public void StartTimer()
    {
        currentTime = countdownTime; // Сброс текущего времени на начальное
        enabled = true; // Включаем обновление скрипта
    }

    public void StopTimer()
    {
        enabled = false; // Выключаем обновление скрипта
    }
    
    
    private void Vibrate()
    {
        if (PlayerPrefs.GetInt("vibrationOn") == 1)
        {
            Debug.Log("Vibrate");
            Handheld.Vibrate();
        }
    }
}
