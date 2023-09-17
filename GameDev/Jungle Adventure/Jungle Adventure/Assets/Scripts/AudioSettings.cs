using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Image soundButton;
    [SerializeField] private Image musicButton;

    [SerializeField] private Color on = new Color(1f, 1f, 1f, 1f);
    [SerializeField] private Color off = new Color(1f, 1f, 1f, 0.5f);

    public int soundOn = 1;
    public int musicOn = 1;

    private void Start()
    {
         soundOn = PlayerPrefs.GetInt("soundOn", 1);
         musicOn = PlayerPrefs.GetInt("musicOn", 1);
         ApplySettings();
    }
    
    public void Sound()
    {
        soundOn = soundOn == 0 ? 1 : 0;
        ApplySettings();
    }

    public void Music()
    {
        musicOn = musicOn == 0 ? 1 : 0;
        ApplySettings();
    }

    private void ApplySettings()
    {
        PlayerPrefs.SetInt("soundOn", soundOn);
        PlayerPrefs.SetInt("musicOn", musicOn);

        soundButton.color = soundOn == 1 ? on : off;
        musicButton.color = musicOn == 1 ? on : off;

        Sound[] sounds = FindObjectOfType<AudioManager>().sounds;
        Sound s = Array.Find(sounds, sound => sound.name == "Theme");
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }
        
        s.source.volume = musicOn == 1 ? 0.3f : 0;

        AudioListener.volume = soundOn == 0 ? 0 : 1;
    }
}
