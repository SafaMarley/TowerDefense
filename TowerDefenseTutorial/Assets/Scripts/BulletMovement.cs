using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 75f;
    public GameObject impactEffect;
    
    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector3 directionToTarget = target.position - transform.position;
            float distanceThisFrame = bulletSpeed * Time.deltaTime;

            if (directionToTarget.magnitude <= distanceThisFrame)
            {
                hitTarget();
            }
            transform.Translate(directionToTarget.normalized * bulletSpeed * Time.deltaTime, Space.World);
        }
    }

    void hitTarget()
    {
        Destroy(gameObject);
        Destroy(target.gameObject);
        GameObject impacteffct = Instantiate(impactEffect, transform.position, impactEffect.gameObject.transform.rotation);
        Destroy(impacteffct, 2f);
    }
}
