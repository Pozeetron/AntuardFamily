using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private bool isFacingRight = false;
    private int _score;
    private int health;
    private int maxHealth = 3;

    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject[] lives;
    [SerializeField] private Text scoreText;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private void Start()
    {
        gameOverMenu.SetActive(false);
        health = maxHealth;
        UpdateLives();
        _score = 0;
        scoreText.text = _score.ToString();
    }

    void Update()
    {
        Flip();
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void MoveLeft()
    {
        horizontal = -1;
    }
    public void MoveRight()
    {
        horizontal = 1;
    }

    public void StopMove()
    {
        horizontal = 0;
    }

    public void IncreaseScore()
    {
        _score++;
        scoreText.text = _score.ToString();
    }
    
    public void TakeDamage()
    {
        health--;
        
        if(PlayerPrefs.GetInt("vibrationOn") == 1)
            Handheld.Vibrate();

        if (health <= 0)
        {
            health = 0;
            Debug.Log("Game Over");
            gameOverMenu.SetActive(true);
        }
        
        UpdateLives();
    }

    private void UpdateLives()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].SetActive(false);
        }

        for (int i = 0; i < health; i++)
        {
            lives[i].SetActive(true);
        }
    }
}
