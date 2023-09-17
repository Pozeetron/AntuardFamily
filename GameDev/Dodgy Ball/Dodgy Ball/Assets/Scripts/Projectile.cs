using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float screenTop;
    private float screenBottom;
    private float screenLeft;
    private float screenRight;
    
    public float speed = 15f;
    public bool canMove;
    private Vector3 _direction;

    private void Start()
    {
        screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    void Update()
    {
        DestroyOutOfBounds();
        
        if(canMove)
            Move();
    }
    
    private void DestroyOutOfBounds()
    {
        if (transform.position.y > screenTop || transform.position.y < screenBottom || 
            transform.position.x < screenLeft || transform.position.x > screenRight)
        {
            FindObjectOfType<Score>().IncreaseScore();
            Destroy(gameObject);
        }
    }

    public void StartMove(Vector3 direction)
    {
        _direction = direction;
        canMove = true;
    }

    private void Move()
    {
        transform.Translate( _direction * speed * Time.deltaTime);
    }
}
