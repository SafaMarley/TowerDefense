using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    
    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    
    [Header("SetupFields")]
    public string enemyTag = "Enemy";
    public Transform rotationPart;
    public float turnSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;


    
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach (GameObject enemy in enemies)
        {
            float distanceFromEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceFromEnemy < shortestDistance)
            {
                shortestDistance = distanceFromEnemy;
                nearestEnemy = enemy;
            }
        }

        if (shortestDistance <= range && nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            Quaternion look = Quaternion.LookRotation(direction);
            Vector3 lookRotation = Quaternion.Lerp(rotationPart.rotation, look, Time.deltaTime * turnSpeed).eulerAngles;

            rotationPart.rotation = Quaternion.Euler(0f, lookRotation.y, 0f);

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletMovement bullet = bulletGo.GetComponent<BulletMovement>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
