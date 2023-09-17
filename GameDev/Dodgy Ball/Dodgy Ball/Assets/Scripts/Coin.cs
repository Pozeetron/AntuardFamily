using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coins;
    
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        Debug.Log(coins);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            coins++;
            PlayerPrefs.SetInt("coins", coins);
            Debug.Log(coins);
            Destroy(gameObject);
        }
    }
}
