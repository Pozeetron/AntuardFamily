using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Vine : MonoBehaviour
{
    public float maxSwingForce = 3f;
    public float minSwingForce = 2f;
    public int maxSwingAngle = 30;
    public int minSwingAngle = 20;
    public float currentSwingForce;
    public float currentSwingAngle;

    private Rigidbody2D rb;
    private bool isSwinging = false;
    private float initialAngle;
    private bool canIncreaseScore = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialAngle = transform.eulerAngles.z;
        currentSwingAngle = Random.Range(minSwingAngle, maxSwingAngle);
        currentSwingForce = Random.Range(minSwingForce, maxSwingForce);
        StartSwinging();
    }

    private void Update()
    {
        if (isSwinging)
        {
            float angle = Mathf.Sin(Time.time * currentSwingForce) * currentSwingAngle;
            transform.eulerAngles = new Vector3(0f, 0f, initialAngle + angle);
        }
    }

    public void StartSwinging()
    {
        isSwinging = true;
    }

    public void StopSwinging()
    {
        isSwinging = false;
        rb.angularVelocity = 0f;
        transform.eulerAngles = new Vector3(0f, 0f, initialAngle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canIncreaseScore)
        {
            Score score = FindObjectOfType<Score>();
            if (score != null)
            {
                score.IncreaseScore();
                canIncreaseScore = false;
            }
        }
    }
}
