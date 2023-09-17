using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int collectedKeys = 0;
    private AudioManager _audioManager;
    
    private float horizontal;
    public float speed = 8f;
    private bool isFacingRight = false;

    public float wallCheckDistance = 0.2f;

    private GravityFlip _gravityFlip;
    private Rigidbody2D _rb;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    [SerializeField] private Door door;
    
    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _rb = GetComponent<Rigidbody2D>();
        _gravityFlip = GetComponent<GravityFlip>();
        horizontal = -1f;
    }

    void Update()
    {
        if (!_gravityFlip.IsGrounded() && !_gravityFlip.IsOnFloor() && IsOnWall())
        {
            StartCoroutine(CallFunctionAndWaitForResult());
        }

        if (collectedKeys == 3)
        {
            door.UnlockDoor();
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(horizontal * speed, _rb.velocity.y);
    }
    
    private void Flip()
    {
        horizontal *= -1;
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private bool IsOnWall() => Physics2D.OverlapCircle(wallCheck.position, wallCheckDistance, wallLayer);
    
    private IEnumerator CallFunctionAndWaitForResult()
    {
        yield return new WaitUntil(() => _gravityFlip.IsGrounded() || _gravityFlip.IsOnFloor());
        Flip();
        if(IsOnWall())
            Flip();
    }

    public void CollectKey()
    {
        collectedKeys++;
        Debug.Log("Keys:" + collectedKeys);
    }
    
    public void Die()
    {
        if (PlayerPrefs.GetString("vibration") == "True")
        {
            Handheld.Vibrate();
            Debug.Log("Vibrate");
        }
        _audioManager.Play("Explosion");
        Destroy(this.gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Spikes"))
        {
            gameObject.SendMessage("LevelFailed");
            Debug.Log("Died");
            Die();
        }
    }

    public void Finish()
    {
        gameObject.SendMessage("FinishLevel");
        Destroy(this.gameObject);
        Debug.Log("Level Finished");
    }
}

