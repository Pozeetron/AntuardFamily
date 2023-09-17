using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool isRotten = false;
    public float fallSpeed = 5f;
    public bool canMove;

    private void Start()
    {
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                if(isRotten)
                    player.TakeDamage();
                else
                    player.IncreaseScore();
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("DeleteTrigger"))
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(canMove)
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }
}
