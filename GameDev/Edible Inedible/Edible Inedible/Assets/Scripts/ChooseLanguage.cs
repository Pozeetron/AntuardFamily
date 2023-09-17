using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLanguage : MonoBehaviour
{
    [SerializeField] public string[] myLangs;
    [SerializeField] private Image[] langs;
    private int _id;

    private Color _transparent = new Color(1f, 1f, 1f, 0.5f);
    private Color _nonTransparent = new Color(1f, 1f, 1f, 1f);

    void Start()
    {
        _id = PlayerPrefs.GetInt ("_language_index", 0);
        PlayerPrefs.SetString("_language", myLangs[_id]);
        
        ChangeUI();
    }

    public void Choose(int id)
    {
        _id = id;
        
        if (_id == 0)
        {
            PlayerPrefs.SetInt("_language_index", _id);
            PlayerPrefs.SetString("_language", myLangs[_id]);
            Debug.Log ("language changed to " + myLangs [_id]);
        }
        
        if (_id == 1)
        {
            PlayerPrefs.SetInt("_language_index", _id);
            PlayerPrefs.SetString("_language", myLangs[_id]);
            Debug.Log ("language changed to " + myLangs [_id]);
        }

        if (_id == 2)
        {
            PlayerPrefs.SetInt("_language_index", _id);
            PlayerPrefs.SetString("_language", myLangs[_id]);
            Debug.Log ("language changed to " + myLangs [_id]);
        }

        ChangeUI();
        
        ApplyLanguageChanges();
    }
    void ApplyLanguageChanges ()
    {
        SceneManager.LoadScene(0);
    }

    private void ChangeUI()
    {
        for (int i = 0; i < langs.Length; i++)
        {
            langs[i].color = _transparent;
        }

        langs[_id].color = _nonTransparent;
    }
}
