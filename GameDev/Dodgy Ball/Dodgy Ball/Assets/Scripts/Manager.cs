using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] obstaclePrefab; 
    public Sprite[] colors;

    private const float StartBallRotationSpeed = 75f;
    private const float StartObstacleRotationSpeed = 35f;

    void Start()
    {
        SpawnObstacle();
        SpawnBall();

        Ball.rotationSpeed = StartBallRotationSpeed;
        Obstacle.rotationSpeed = StartObstacleRotationSpeed;
    }

    public void ChangeObstacle()
    {
        Destroy(FindObjectOfType<Obstacle>().gameObject);
        SpawnObstacle();

        Ball.rotationSpeed += 5;
        Obstacle.rotationSpeed += 5;
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Length - 1)], Vector3.zero, Quaternion.identity);
    }

    private void SpawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        newBall.GetComponent<SpriteRenderer>().sprite = colors[PlayerPrefs.GetInt("selectedBall", 0)];
    }
}
