using System;
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

    public void PurchaseStandartTurret ()
    {
        Debug.Log("standart selected");
        _buildManager.SetTurretToBuild(_buildManager.standartTurretPrefab);
    }

    public void PurchasedAnotherTurret ()
    {
        Debug.Log("another one selected");
        _buildManager.SetTurretToBuild(_buildManager.anotherTurretPrefab);

    }
}
