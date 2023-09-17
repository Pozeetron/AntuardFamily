using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private float _currentMoveSpeed;
    public float jumpForce = 5f;
    [SerializeField] private Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    public bool isGrounded;

    private void Start()
    {
        _currentMoveSpeed = 0;
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        isGrounded = IsGrounded();

        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            FindObjectOfType<AudioManager>().Play("Bouce");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_currentMoveSpeed, rb.velocity.y);
    }
    
    private bool IsGrounded() => Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Die();
        }
    }

    public void Die()
    {
        SendMessage("LevelFailed");
        if (PlayerPrefs.GetString("vibration") == "True")
        {
            Debug.Log("Vibrate");
            Handheld.Vibrate();
        }
        Destroy(gameObject);
        this.enabled = false;
    }
    
    public void Finish()
    {
        gameObject.SendMessage("FinishLevel");
        Destroy(this.gameObject);
        Debug.Log("Level Finished");
    }
    
    
    public void MoveRight()
    {
        _currentMoveSpeed = moveSpeed;
    }
    public void MoveLeft()
    {
        _currentMoveSpeed = -moveSpeed;
    }
    public void StopMoveRightLeft()
    {
        _currentMoveSpeed = 0;
    }
}
