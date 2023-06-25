using System.Collections;
using System.Collections.Generic;
using Managers;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteInEditMode]
public class MapGenerator : MonoBehaviour
{
    public bool GenerateMapOrder;
    
    public MapManager mapManager;
    public List<Material> colorList;
    private void Update()
    {
        if (GenerateMapOrder)
        {
            GenerateMapOrder = false;
            GenerateMap();
        }
    }
    
    public void GenerateMap()
    {
        DeleteCurrentMap();
        Dictionary<Vector2, Hexagon> hexagonDic = new();
        for (var x = 0; x < mapManager.mapSize.x; x++)
        {
            for (var y = 0; y < mapManager.mapSize.y; y++)
            {
                var hexagon = Instantiate(mapManager.hexagonPrefab).GetComponent<Hexagon>();
                var pos = new Vector3(x, y + (x % 2 == 0 ? 0 : 0.5f));
                hexagon.transform.position = pos;
                hexagon.name = $"({x.ToString()}, {y.ToString()})";
                hexagonDic.Add(pos, hexagon);
                hexagon.hexagonType = GetRandomHexagonType();
                hexagon.meshRenderer.material = colorList[(int)hexagon.hexagonType];
            }
        }
        mapManager.hexagonDic = hexagonDic;
    }

    private HexagonType GetRandomHexagonType()
    {
        var value = Random.Range(0, 4);
        if (value == 0)
        {
            return HexagonType.IndustrialCity;
        }
        else if (value == 1)
        {
            return HexagonType.Slums;
        }
        else if (value == 2)
        {
            return HexagonType.Wasteland;
        }
        return HexagonType.Fertile;
    }

    public void DeleteCurrentMap()
    {
        foreach (var hexagon in mapManager.hexagonDic.Values)
        {
            DestroyImmediate(hexagon.gameObject);
        }
    }


}
