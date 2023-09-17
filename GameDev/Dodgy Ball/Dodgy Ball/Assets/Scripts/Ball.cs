using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject projectilePrefab;
    public static float rotationSpeed = 75f;

    [SerializeField] private Transform projectileSpawner;

    public static bool canInput;
    public bool canShoot;

    private Manager _manager;

    private void Start()
    {
        canInput = true;
        canShoot = true;

        _manager = FindObjectOfType<Manager>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canInput)
        {
            Shoot();
        }
        
        transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        if (canShoot)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawner.position, Quaternion.identity);

            projectile.GetComponent<Projectile>().StartMove(transform.right);
            projectile.GetComponent<SpriteRenderer>().sprite = _manager.colors[PlayerPrefs.GetInt("selectedBall", 0)];

            canShoot = false;
            
            StartCoroutine(ResetShootCooldown());
        }
    }

    IEnumerator ResetShootCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        
        canShoot = true;
    }
}
