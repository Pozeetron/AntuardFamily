using System;
using UnityEngine;

public class AIChasing : MonoBehaviour
{
    private Transform target;
    public float moveSpeed = 4f;

    private void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void IsDead()
    {
        this.enabled = false;
    }
}
