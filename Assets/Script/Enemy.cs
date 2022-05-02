using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform _target;
    private int _wavePointIndex = 0;
    private void Start()
    {
        _target = Waypoints.waypoints[0];
    }
    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, _target.position) < 0.2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (_wavePointIndex >= Waypoints.waypoints.Length-1)
        {
            Destroy(gameObject);
            return;
        }
        _wavePointIndex++;
        _target = Waypoints.waypoints[_wavePointIndex];
    }
}
