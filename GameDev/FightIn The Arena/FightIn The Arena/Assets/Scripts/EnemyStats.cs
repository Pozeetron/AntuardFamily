using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    private int _currentHealth;
    public int score;

    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        _animator.SetTrigger("Hurt");
        
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<ScoreManager>().UpdateScoreUI(score);
        _animator.SetBool("IsDead", true);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        SendMessage("IsDead");
        Destroy(this.gameObject, 3f);
    }
}
