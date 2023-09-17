using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static bool canClick;
    public int id;
    private Manager _gameManager;

    private void Start()
    {
        canClick = true;
        _gameManager = FindObjectOfType<Manager>();
    }

    private void OnMouseDown()
    {
        if (canClick)
        {
            _gameManager.ItemClicked(id);
            Destroy(gameObject);
        }
    }
}
