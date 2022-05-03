using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed=70f;
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
    }
    private void HitTarget()
    {
        GameObject obj=(GameObject)Instantiate(impactEffect,transform.position,transform.rotation);
        Destroy(obj, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
