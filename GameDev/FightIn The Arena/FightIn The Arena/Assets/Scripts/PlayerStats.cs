using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    private int _currentHealth;
    [SerializeField] private Image[] healthSprites;
    [SerializeField] private GameObject gameOverScreen;

    private Animator _animator;
    void Start()
    {
        gameOverScreen.SetActive(false);
        _animator = GetComponent<Animator>();
        _currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log(_currentHealth);
        
        _animator.SetTrigger("Hurt");

        UpdateHealthUI();
        
        FindObjectOfType<AudioManager>().Play("Hurt");

        if (PlayerPrefs.GetString("vibration") == "True")
        {
            Handheld.Vibrate();
            Debug.Log("Vibrate");
        }

        
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeHeal(int heal)
    {
        _currentHealth += heal;

        if (_currentHealth >= maxHealth)
        {
            _currentHealth = maxHealth;
        }
        
        UpdateHealthUI();
        
        Debug.Log(_currentHealth);
    }

    private void Die()
    {
        FindObjectOfType<AudioManager>().Play("Die");
        gameOverScreen.SetActive(true);
        this.enabled = false;
        SendMessage("IsDead");
        GetComponent<Collider2D>().enabled = false;
        _animator.SetBool("IsDead", true);
    }

    private void UpdateHealthUI()
    {
        if (_currentHealth < 75)
        {
            healthSprites[2].enabled = false;
        }
        else
        {
            healthSprites[2].enabled = true;
        }
        
        if (_currentHealth < 50)
        {
            healthSprites[1].enabled = false;
        }
        else
        {
            healthSprites[1].enabled = true;
        }
        
        if (_currentHealth <= 0)
        {
            healthSprites[0].enabled = false;
        }
        else
        {
            healthSprites[0].enabled = true;
        }
    }
}
