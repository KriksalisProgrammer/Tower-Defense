using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private  Transform _target;
    [Header("Unity Setup Fields")]
    private string _enemyTag = "Enemy";

    public Transform rotateTurret;

    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Attributes")]
    public float range=15f;
    public float fireRate = 1f;
    public float fireCountDown = 0f;
    public float turnSpeed = 10f;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if(_target==null)
            return;

        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotateTurret.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
        rotateTurret.rotation = Quaternion.Euler(0,rotation.y, 0);

        if(fireCountDown<=0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }
    private void Shoot()
    {
       GameObject bulletGameObject= (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(_target);
        }
    }
    private void UpdateTarget()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag(_enemyTag);

        float shortDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        foreach(var enemy in enemys)
        {
            float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
            if(distanceToEnemy < shortDistance)
            {
                shortDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortDistance<=range )
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
