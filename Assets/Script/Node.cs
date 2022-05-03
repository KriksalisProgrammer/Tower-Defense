using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer _rend;
    private Color _startColor;

    private GameObject _turret;

    public Color hoverColor;
    
    private void Start()
    {
        _rend=GetComponent<Renderer>();
        _startColor=_rend.material.color;
    }
    private void OnMouseDown()
    {
        if(_turret!=null)
        {
            Debug.Log("We Can Build!");
            return;
        }
        GameObject turretToBuild=BuildManager.instance.GetTurretToBuild();
        _turret =(GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }
    private void OnMouseEnter()
    {
        _rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}
