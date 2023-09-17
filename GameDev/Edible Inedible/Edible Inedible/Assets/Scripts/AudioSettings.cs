using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Image[] soundButton;
    [SerializeField] private Image[] vibrationButton;

    private Color on = new Color(1f, 1f, 1f, 1f);
    private Color off = new Color(1f, 1f, 1f, 0.5f);

    public int soundOn = 1;
    public int vibrationOn = 1;

    private void Start()
    {
         soundOn = PlayerPrefs.GetInt("soundOn", 1);
         vibrationOn = PlayerPrefs.GetInt("vibrationOn", 1);
         ApplySettings();
    }


    public void SoundOn()
    {
        soundOn = 1;
        ApplySettings();
    }

    public void SoundOff()
    {
        soundOn = 0;
        ApplySettings();
    }
    
    public void VibrationOn()
    {
        vibrationOn = 1;
        Handheld.Vibrate();
        Debug.Log("Vibrate");
        ApplySettings();
    }

    public void VibrationOff()
    {
        vibrationOn = 0;
        ApplySettings();
    }

    private void ApplySettings()
    {
        PlayerPrefs.SetInt("soundOn", soundOn);
        PlayerPrefs.SetInt("vibrationOn", vibrationOn);

        soundButton[0].color = soundOn == 0 ? on : off;
        soundButton[1].color = soundOn == 1 ? on : off;
        
        vibrationButton[0].color = vibrationOn == 0 ? on : off;
        vibrationButton[1].color = vibrationOn == 1 ? on : off;

        AudioListener.volume = soundOn == 0 ? 0 : 1;
    }
}
