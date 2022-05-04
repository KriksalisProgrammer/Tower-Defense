using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;
    private void Start()
    {
        _buildManager = BuildManager.instance;
    }
    public void PurchaseStandartTurret()
    {
        _buildManager.SetTurretToBuild(_buildManager.standartTurrentPrefab);
    }

    public void AnotherPurchaseTurret()
    {
        _buildManager.SetTurretToBuild(_buildManager.anotherTurretPrefab);
    }
}
