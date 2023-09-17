using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLanguage : MonoBehaviour
{
    [SerializeField] public string[] myLangs;
    private int _id = -1;
    [SerializeField] private Image imageEN;
    [SerializeField] private Image imageRU;
    [SerializeField] private Image imageBR;

    private Color _transparent = new Color(1f, 1f, 1f, 0.5f);
    private Color _nonTransparent = new Color(1f, 1f, 1f, 1f);
    void Start()
    {
        _id = PlayerPrefs.GetInt ("_language_index", 0);
        if (_id == -1)
        {
            _id = 0;
            PlayerPrefs.SetInt("_language_index", _id);
        }
        PlayerPrefs.SetString("_language", myLangs[_id]);
    }

    private void Update()
    {
        if (_id == 0) //en
        {
            imageEN.color = _nonTransparent;
            imageRU.color = _transparent;
            imageBR.color = _transparent;
        }
        else if (_id == 1) //ru
        {
            imageEN.color = _transparent;
            imageRU.color = _nonTransparent;
            imageBR.color = _transparent;
        }
        else if (_id == 2) //br
        {
            imageEN.color = _transparent;
            imageRU.color = _transparent;
            imageBR.color = _nonTransparent;
        }
    }

    public void Choose(int id)
    {
        _id = id;
        PlayerPrefs.SetInt("_language_index", id);
        PlayerPrefs.SetString("_language", myLangs[_id]);
        Debug.Log ("language changed to " + myLangs [_id]);
        ApplyLanguageChanges();
    }
    void ApplyLanguageChanges ()
    {
        SceneManager.LoadScene (0);
    }
}
