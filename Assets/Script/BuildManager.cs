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

    private TurretBluePrint _turretToBuild;

    public bool CanBuild
    {
        get { return _turretToBuild != null; }
    }
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < _turretToBuild.Cost)
        {
            Debug.Log("Not Money to build that!");
            return;
        }
        PlayerStats.Money-=_turretToBuild.Cost;

        GameObject turret = (GameObject)Instantiate(_turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Money left:" + PlayerStats.Money);
    }
    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        _turretToBuild = turret;
    }
}
