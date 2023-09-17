using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float totalTime = 60.0f;
    public float currentTime;
    private bool isTimerRunning = false;

    void Start()
    {
        StartTimer();
        currentTime = totalTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();

            if (currentTime <= 0)
            {
                StopTimer();
            }
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = totalTime;
        UpdateTimerDisplay();
        isTimerRunning = false;
    }

    private void UpdateTimerDisplay()
    {
        timerText.text = currentTime.ToString("F2");
    }

    public void ReduceTime()
    {
        currentTime -= 5f;
    }
}
