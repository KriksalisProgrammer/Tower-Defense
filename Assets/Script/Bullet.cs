using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed=70f;
    public float explotionRange = 0f;
    public GameObject impactEffect;
    public void Seek(Transform _target)
    {
        target=_target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distnce = speed * Time.deltaTime;

        if(direction.magnitude<=distnce)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distnce, Space.World);
        transform.LookAt(target);
    }
    private void HitTarget()
    {
        GameObject obj=(GameObject)Instantiate(impactEffect,transform.position,transform.rotation);
        Destroy(obj, 5f);

        if(explotionRange>0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
           
        }
        Destroy(gameObject);

    }
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explotionRange);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    private void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explotionRange);
    }
}
