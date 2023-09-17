using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private Text jumpText;
    public int startJumps = 15;
    public int currentJumps;
    public bool gameOver;
    [SerializeField] private GameObject gameOverMenu;
    public Vector2 jumpForce = new Vector2(4f, 3f);
    [SerializeField] private Sprite[] monsters;
    [SerializeField] private SpriteRenderer currentMonster;
    
    void Start()
    {
        currentMonster.sprite = monsters[PlayerPrefs.GetInt("selectedMonster", 0)];
        currentJumps = startJumps;
        jumpText.text = currentJumps.ToString();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(gameOver)
            return;
        
        if (Input.GetMouseButtonDown(0) && currentJumps > 0)
        {
            Jump();
        }
    }
    
    void Jump()
    {
        _rb.velocity = jumpForce;
        currentJumps--;
        if (currentJumps <= 0)
        {
            currentJumps = 0;
            GameOver();
        }
        jumpText.text = currentJumps.ToString();
    }

    public void IncreaseJumps()
    {
        currentJumps += 5;
        jumpText.text = currentJumps.ToString();
    }

    public void GameOver()
    {
        if(PlayerPrefs.GetInt("vibrationOn") == 1)
            Handheld.Vibrate();
        gameOver = true;
        gameOverMenu.SetActive(true);
    }
    
}
