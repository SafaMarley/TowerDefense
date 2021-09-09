using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 turretOffset = new Vector3(0f, 0.5f, 0f);

    private GameObject turret;
    private Renderer materialRenderer;
    private Color startingColor;
    
    private void Start()
    {
        materialRenderer = GetComponent<Renderer>();
        startingColor = materialRenderer.material.color;
    }

    private void OnMouseEnter()
    {
        materialRenderer.material.color = hoverColor;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there!");
        }
        else
        {
            //Instantiate(turret, transform.position, transform.rotation);
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = Instantiate(turretToBuild, transform.position + turretOffset, transform.rotation);
        }
    }

    private void OnMouseExit()
    {
        materialRenderer.material.color = startingColor;
    }
}
