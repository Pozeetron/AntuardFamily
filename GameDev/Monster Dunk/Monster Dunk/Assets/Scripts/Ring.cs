using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ring : MonoBehaviour
{
    public float minY = -3f;
    public float maxY = 4f;
    public float moveSpeed = 2f;

    private bool movingUp;
    private bool[] randMove = new[] { true, false };
    private float[] randRot = new[] { -30f, 30f };

    public float rotationSpeed = 30.0f;
    public bool rotateClockwise = true;
    private void Start()
    {
        movingUp = randMove[Random.Range(0, randMove.Length)];
        StartCoroutine(MoveUpDown());
        
        transform.rotation = Quaternion.Euler(0, 0, randRot[Random.Range(0, randRot.Length)]);
        StartCoroutine(RotateObject());
    }

    private IEnumerator RotateObject()
    {
        while (true)
        {
            float targetRotation = rotateClockwise ? -30.0f : 30.0f;

            while (transform.rotation != Quaternion.Euler(0, 0, targetRotation))
            {
                float step = rotationSpeed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, targetRotation), step);
                yield return null;
            }
            
            rotateClockwise = !rotateClockwise;

            yield return null;
        }
    }

    private IEnumerator MoveUpDown()
    {
        while (true)
        {
            float targetY = movingUp ? maxY : minY;
            Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);

            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            movingUp = !movingUp;

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsObjectFromTop(other) && other.CompareTag("Player"))
        {
            Debug.Log("Объект вошел сверху!");
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                if(PlayerPrefs.GetInt("vibrationOn") == 1)
                    Handheld.Vibrate();
                player.jumpForce.x *= -1;
                player.IncreaseJumps();
                Instantiate(gameObject, new Vector3(transform.position.x * -1, 0f, 0f), Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private bool IsObjectFromTop(Collider2D collider)
    {
        Vector2 triggerCenter = transform.position;

        Vector2 objectCenter = collider.bounds.center;

        return objectCenter.y > triggerCenter.y;
    }
}
