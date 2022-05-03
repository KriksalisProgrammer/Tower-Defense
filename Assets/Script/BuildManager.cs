using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance !=null)
        {
            Debug.LogError("More!");
            return;
        }
        instance = this;
        
    }
    public GameObject standartTurrentPrefab;
    private void Start()
    {
        _turretToBuild = standartTurrentPrefab;
    }
    private GameObject _turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }
}
