using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMonster : MonoBehaviour
{
    private List<int> colors = new List<int>() { 0, 0, 0, 0, 1 };
    public int selectedMonster;
    [SerializeField] private Image[] montsersButton;
    [SerializeField] private Image[] montsersImage;
    private Color _transparent = new Color(1f, 1f, 1f, 0.5f);
    private Color _nonTransparent = new Color(1f, 1f, 1f, 1f);
    
    void Start()
    {

        selectedMonster = PlayerPrefs.GetInt("selectedMonster", 4);

        colors[0] = PlayerPrefs.GetInt("lightBlue", 0);
        colors[1] = PlayerPrefs.GetInt("yellow", 0);
        colors[2] = PlayerPrefs.GetInt("purple", 0);
        colors[3] = PlayerPrefs.GetInt("blue", 0);
        colors[4] = PlayerPrefs.GetInt("red", 1);

        PlayerPrefs.SetInt("selectedMonster", selectedMonster);
        
        PlayerPrefs.SetInt("lightBlue", colors[0]);
        PlayerPrefs.SetInt("yellow", colors[1]);
        PlayerPrefs.SetInt("purple", colors[2]);
        PlayerPrefs.SetInt("blue", colors[3]);
        PlayerPrefs.SetInt("red", colors[4]);
        
        UpdateUI();
    }

    public void Select(int id)
    {
        string color = id == 0 ? "lightBlue" : id == 1 ? "yellow" : id == 2 ? "purple" : id == 3 ? "blue" : id == 4 ? "red" : String.Empty;
        
        colors[id] = 1;

        selectedMonster = id;
        PlayerPrefs.SetInt("selectedMonster", selectedMonster);

        PlayerPrefs.SetInt(color, 1);
        
        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < montsersButton.Length; i++)
        {
            montsersButton[i].color = _transparent;
            montsersImage[i].color = _transparent;
        }
        
        montsersImage[selectedMonster].color = _nonTransparent;
        montsersButton[selectedMonster].color = _nonTransparent;
    }
}
