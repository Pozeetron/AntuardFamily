using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float parallaxSpeed = 1f;

    private Vector2 backGroundStartPos;
    private Vector2 playerStartPos;
    
    void Start()
    {
        playerStartPos = player.transform.position;
        backGroundStartPos = transform.position;
    }
    
    void Update()
    {
        float playerDeltaX = player.position.x - playerStartPos.x;
       
        transform.position = new Vector3(backGroundStartPos.x + playerDeltaX, backGroundStartPos.y, 0f);
    }
}
