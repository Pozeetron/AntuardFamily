using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public bool soundOn;
    public bool vibrationOn;

    public string sound = string.Empty;
    public string vibration = string.Empty;
    
    [SerializeField] private Image soundImage;
    [SerializeField] private Image vibrationImage;

    private Color _transparent = new Color(1f, 1f, 1f, 0.5f);
    private Color _nonTransparent = new Color(1f, 1f, 1f, 1f);
    private void Start()
    {
        sound = PlayerPrefs.GetString("sound");
        if (sound == string.Empty && !soundOn)
        {
            sound = "True";
            soundOn = true;
        }
        vibration = PlayerPrefs.GetString("vibration");
        if (vibration == string.Empty && !vibrationOn)
        {
            vibration = "True";
            vibrationOn = true;
        }
        else
        {
            vibrationOn = false;
        }
        ChangeSettings();
    }
    
    public void ChangeSettings()
    {
        sound = PlayerPrefs.GetString("sound");
        vibration = PlayerPrefs.GetString("vibration");
        if (sound == "True")
        {
            soundImage.color = _nonTransparent;
            AudioListener.volume = 1;
        }
        else
        {
            soundImage.color = _transparent;
            AudioListener.volume = 0;
        }
        
        if (vibration == "True")
        {
            vibrationImage.color = _nonTransparent;
        }
        else
        {
            vibrationImage.color = _transparent;
        }
    }
    
    
    public void SoundSetting()
    {
        soundOn = !soundOn;
        PlayerPrefs.SetString("sound", soundOn.ToString());
        ChangeSettings();
    }
    
    public void VibrationSetting()
    {
        vibrationOn = !vibrationOn; 
        PlayerPrefs.SetString("vibration", vibrationOn.ToString());
        ChangeSettings();
    }
}
