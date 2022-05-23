using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standartTurret;
    public TurretBluePrint missileTurret;

    private BuildManager _buildManager;
    private void Start()
    {
        _buildManager = BuildManager.instance;
    }
    public void SelectStandartTurret()
    {
        _buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectPurchaseTurret()
    {
        _buildManager.SelectTurretToBuild(missileTurret);
    }
}
