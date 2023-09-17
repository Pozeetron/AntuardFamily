using System;
using UnityEngine;

public class Door : MonoBehaviour
{ 
    private SpriteRenderer _doorSprite;
    [SerializeField] private Sprite unlockedDoor;
    private bool _unlocked;

    private void Start()
    {
        _doorSprite = GetComponent<SpriteRenderer>();
        _unlocked = false;
    }

    public void UnlockDoor()
    {
        _doorSprite.sprite = unlockedDoor;
        Debug.Log("Door is unlocked");
        _unlocked = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                if(_unlocked)
                    player.Finish();
            }
        }
    }
}
