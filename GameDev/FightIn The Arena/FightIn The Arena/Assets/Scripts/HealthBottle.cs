using UnityEngine;

public class HealthBottle : MonoBehaviour
{
    public int heal = 30;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.TakeHeal(heal);
                Destroy(this.gameObject);
            }
        }
    }
}
