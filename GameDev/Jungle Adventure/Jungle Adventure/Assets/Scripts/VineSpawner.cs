using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VineSpawner : MonoBehaviour
{ 
    public GameObject vinePrefab; // Префаб создаваемого объекта
    public float distance = 8f; // Расстояние между создаваемыми объектами
    public float spawnInterval = 2f;
    public Transform player;
    public bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(SpawnVine());
    }

    private void Update()
    {
        if (distance - Mathf.Abs(player.position.x) > 30)
            canSpawn = false;
        else
            canSpawn = true;
    }

    IEnumerator SpawnVine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (canSpawn)
            {
                Instantiate(vinePrefab, new Vector3(5 + distance, Random.Range(5.5f, 6.5f), 0f), Quaternion.identity);
                distance += 8;
            }
        }
    }
}
