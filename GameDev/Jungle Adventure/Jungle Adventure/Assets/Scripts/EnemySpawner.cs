using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб создаваемого объекта
    public float spawnInterval = 5f;

    private void Start()
    {
        StartCoroutine(SpawnVine());
    }

    IEnumerator SpawnVine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(transform.position.x, Random.Range(-3f, 4f), 0f), Quaternion.identity);
            enemy.GetComponent<Enemy>().StartMove();
        }
    }
}
