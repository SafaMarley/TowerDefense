using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 turretOffset = new Vector3(0f, 0.5f, 0f);

    private GameObject turret;
    private Renderer materialRenderer;
    private Color startingColor;

    private BuildManager _buildManager;
    
    private void Start()
    {
        materialRenderer = GetComponent<Renderer>();
        startingColor = materialRenderer.material.color;
        _buildManager = BuildManager.instance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (_buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        
        materialRenderer.material.color = hoverColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (_buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        
        if (turret != null)
        {
            Debug.Log("Can't build there!");
        }
        else
        {
            //Instantiate(turret, transform.position, transform.rotation);
            GameObject turretToBuild = _buildManager.GetTurretToBuild();
            turret = Instantiate(turretToBuild, transform.position + turretOffset, transform.rotation);
        }
    }

    private void OnMouseExit()
    {
        materialRenderer.material.color = startingColor;
    }
}
