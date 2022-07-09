using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Turret : MonoBehaviour
{
    //  target to aim and kill
    private Transform target;
    
    [Header("Turret")]
    public Transform headOfTurret;
    public float turnSpeed = 10f;
    public float range = 15f;
    
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    public GameObject bulletPrefab;
    public Transform[] firePoints;
    
    [Space(15)]
    //  tag
    public string enemyTag = "Enemy";

    private void Start()
    {
        headOfTurret = transform.GetChild(0);
        firePoints = headOfTurret.transform.GetChild(1).GetComponentsInChildren<Transform>();
        
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }

    private void Update()
    {
        if (target == null)
        {
            // headOfTurret.rotation = quaternion.Euler(Vector3.zero);
            return;
        }

        RotateHead();

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    private void Shoot()
    {
        int rand = Random.Range(1, firePoints.Length);
        GameObject bullet = Instantiate(bulletPrefab, firePoints[rand].position, firePoints[rand].rotation);
        // Debug.Log(firePoints[rand]);
        bullet.transform.SetParent(headOfTurret);
        
        Bullet bulletSc = bullet.GetComponent<Bullet>();
        if (bulletSc != null)
        {
            bulletSc.Seek(target);
        }
    }

    public void RotateHead()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(headOfTurret.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        headOfTurret.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    

    public void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDisntance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDisntance) 
            {
                shortestDisntance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDisntance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}