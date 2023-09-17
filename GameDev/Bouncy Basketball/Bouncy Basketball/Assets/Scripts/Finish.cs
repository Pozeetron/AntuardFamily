using UnityEngine;

public class Finish : MonoBehaviour
{
    public float allowedYDifference = 0.5f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                float yDifference = Mathf.Abs(transform.position.y - player.transform.position.y);

                if (yDifference <= allowedYDifference && player.transform.position.y > transform.position.y)
                {
                    Debug.Log("LevelFinished");
                    player.Finish();
                }
            }
                
        }
    }
}
