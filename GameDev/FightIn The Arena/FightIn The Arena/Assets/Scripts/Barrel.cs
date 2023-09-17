using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public int health = 50;
    [SerializeField] private GameObject healthBottle;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(healthBottle ,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
