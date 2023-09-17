using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static float rotationSpeed = 35f;

    private void Update()
    { 
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            GameObject canvas = GameObject.Find("UI");
            if (canvas != null)
            {
                Transform leaderBoard = canvas.transform.Find("LeaderBoardMenu");
                if (leaderBoard != null)
                {
                    leaderBoard.gameObject.SetActive(true);
                }
                else
                {
                    Debug.LogError("LeaderBoard error");
                }
            }
            else
            {
                Debug.LogError("Canvas error");
            }
            
            Ball.canInput = false;
        }
    }
}
