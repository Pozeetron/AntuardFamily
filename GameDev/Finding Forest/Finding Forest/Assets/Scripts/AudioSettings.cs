using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Image soundButton;
    [SerializeField] private Image vibrationButton;

    [SerializeField] private Color on = new Color(1f, 1f, 1f, 1f);
    [SerializeField] private Color off = new Color(1f, 1f, 1f, 0.5f);

    [SerializeField] private Text soundText;
    [SerializeField] private Text vibrationText;

    public int soundOn = 1;
    public int vibrationOn = 1;

    private void Start()
    {
         soundOn = PlayerPrefs.GetInt("soundOn", 1);
         vibrationOn = PlayerPrefs.GetInt("vibrationOn", 1);
         ApplySettings();
    }
    
    public void Sound()
    {
        soundOn = soundOn == 0 ? 1 : 0;
        ApplySettings();
    }

    public void Vibration()
    {
        vibrationOn = vibrationOn == 0 ? 1 : 0;
        if(vibrationOn == 1)
            Handheld.Vibrate();
        ApplySettings();
    }

    private void ApplySettings()
    {
        PlayerPrefs.SetInt("soundOn", soundOn);
        PlayerPrefs.SetInt("vibrationOn", vibrationOn);

        soundButton.color = soundOn == 1 ? on : off;
        vibrationButton.color = vibrationOn == 1 ? on : off;

        soundText.text = soundOn == 1 ? "SOUND ON" : "SOUND OFF";
        vibrationText.text = vibrationOn == 1 ? "VIBRATION ON" : "VIBRATION OFF";

        AudioListener.volume = soundOn == 0 ? 0 : 1;
    }
}
