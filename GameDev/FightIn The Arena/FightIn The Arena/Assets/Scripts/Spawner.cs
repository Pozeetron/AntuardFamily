using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Префаб объекта для спавна
    public Vector2 spawnAreaMin; // Минимальные координаты области спавна
    public Vector2 spawnAreaMax; // Максимальные координаты области спавна
    public float spawnInterval = 2.0f; // Интервал между спавнами

    private float timeSinceLastSpawn = 0.0f;

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObject();
            timeSinceLastSpawn = 0.0f; // Сбросить счетчик времени
        }
    }

    private void SpawnObject()
    {
        // Генерируем случайные координаты для спавна в пределах заданной области
        int randomInd = Random.Range(0, objectsToSpawn.Length);
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        // Создаем новый объект из префаба и размещаем его на случайной позиции
        GameObject newObject = Instantiate(objectsToSpawn[randomInd], spawnPosition, Quaternion.identity);

        // Можно добавить дополнительную логику для настройки объекта после спавна
    }
}
