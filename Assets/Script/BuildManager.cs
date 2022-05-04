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

    public GameObject anotherTurretPrefab;

    private GameObject _turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }
    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }
}
