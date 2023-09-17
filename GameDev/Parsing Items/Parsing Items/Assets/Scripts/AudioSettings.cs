using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Image[] soundButton;
    [SerializeField] private Image[] vibrationButton;

    [SerializeField] private Sprite[] on;
    [SerializeField] private Sprite[] off;

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

        soundButton[0].sprite = soundOn == 0 ? off[1] : off[0];
        soundButton[1].sprite = soundOn == 1 ? on[1] : on[0];
        
        vibrationButton[0].sprite = vibrationOn == 0 ? off[1] : off[0];
        vibrationButton[1].sprite = vibrationOn == 1 ? on[1] : on[0];

        AudioListener.volume = soundOn == 0 ? 0 : 1;
    }
}
