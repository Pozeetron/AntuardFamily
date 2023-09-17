using System;
using System.Collections;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int attackDamage = 20;
    public float damageInterval = 1f;
    private float lastDamageTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.TakeDamage(attackDamage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time - lastDamageTime >= damageInterval)
            {
                PlayerStats player = other.GetComponent<PlayerStats>();
                if (player != null)
                {
                    player.TakeDamage(attackDamage);
                    lastDamageTime = Time.time;
                }
            }
        }
    }

    private void IsDead()
    {
        this.enabled = false;
    }

}
