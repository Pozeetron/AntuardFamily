using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float fallSpeed = 3f;
    public bool canMove;
    public bool isDead = false;
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(canMove)
            Move();
        
        if (isDead)
           StartFall();
        
        _animator.SetBool("CanMove", canMove);
        _animator.SetBool("IsDead", isDead);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage();
            }
        }
    }

    private void Move()
    {
        transform.Translate(-Vector2.right * speed * Time.deltaTime);
    }

    public void StartMove()
    {
        canMove = true;
    }

    public void StopMove()
    {
        canMove = false;
    }

    public void Death()
    {
        isDead = true;
        StopMove();
        GetComponent<Collider2D>().enabled = false;
    }

    private void StartFall()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }
}
