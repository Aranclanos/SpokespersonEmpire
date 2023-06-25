using System;
using System.Collections;
using System.Collections.Generic;
using Buildings;
using TMPro;
using Units;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public MeshRenderer selectorMeshRenderer;
    public TextMeshProUGUI perceptionText;

    private float publicPerception = 50;
    [NonSerialized] public HexagonType hexagonType;
    private List<Building> buildingList = new List<Building>();
    public Unit unit;

    private void Awake()
    {
        UpdateUI();
    }

    public void AffectPublicPerception(float value)
    {
        publicPerception += value * Time.deltaTime;
        if (publicPerception < 0)
        {
            publicPerception = 50;
            foreach (var building in buildingList)
            {
                Destroy(building.gameObject);
            }
        }
        else if (publicPerception > 100)
        {
            publicPerception = 100;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        perceptionText.text = $"{((int)publicPerception).ToString()}%";
    }

    public void AddBuilding(Building building)
    {
        buildingList.Add(building);
    }

    public void RemoveBuilding(Building building)
    {
        buildingList.Remove(building);
    }
}
