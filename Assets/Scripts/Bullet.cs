using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    
    public float speed = 70;
    public int damage = 20;

    public GameObject impactEffect;
    
    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        GameObject impEff = Instantiate(impactEffect, transform.position, transform.rotation);
        impEff.transform.SetParent(GameManager.effectHolder);
        Destroy(impEff, 2f);
        
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);        
        }
    }
}