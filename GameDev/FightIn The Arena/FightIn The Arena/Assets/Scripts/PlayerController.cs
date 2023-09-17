using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Animator _animator;
    private bool isFacingRight = true;

    [SerializeField] private Sprite[] heroSprites;
    [SerializeField] private Sprite[] gunSprites;
    [SerializeField] private SpriteRenderer heroSprite;
    [SerializeField] private SpriteRenderer heroGunSprite;
    private string _currentHeroSprite;
    
    void Start()
    {
        _currentHeroSprite = PlayerPrefs.GetString("hero");
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        switch (_currentHeroSprite)
        {
            case "wizard":
                heroSprite.sprite = heroSprites[0];
                heroGunSprite.sprite = gunSprites[0];
                break;
            case "knight":
                heroSprite.sprite = heroSprites[1];
                heroGunSprite.sprite = gunSprites[1];
                break;
            case "elf":
                heroSprite.sprite = heroSprites[2];
                heroGunSprite.sprite = gunSprites[2];
                break;
            case "blackSmith":
                heroSprite.sprite = heroSprites[3];
                heroGunSprite.sprite = gunSprites[3];
                break;
            case "man":
                heroSprite.sprite = heroSprites[4];
                heroGunSprite.sprite = gunSprites[4];
                break;
            case "armored":
                heroSprite.sprite = heroSprites[5];
                heroGunSprite.sprite = gunSprites[5];
                break;
                
        }
    }

    void Update()
    {
        _animator.SetFloat("Speed", _movement.sqrMagnitude);
        
        Flip();
    }

    public void MoveUp()
    {
        _movement.y = 1;
    }
    public void MoveDown()
    {
        _movement.y = -1;
    }
    public void StopMoveUpDown()
    {
        _movement.y = 0;
    }

    public void MoveRight()
    {
        _movement.x = 1;
    }
    public void MoveLeft()
    {
        _movement.x = -1;
    }
    public void StopMoveRightLeft()
    {
        _movement.x = 0;
    }

    private void Flip()
    {
        if (isFacingRight && _movement.x < 0f || !isFacingRight && _movement.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void IsDead()
    {
        this.enabled = false;
    }
    
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.deltaTime);
    }
}
