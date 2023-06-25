using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Managers
{
	public class MapManager : MonoBehaviourSingleton<MapManager>
	{
		public GameObject hexagonPrefab;
		public MapGenerator mapGenerator;
		public Vector2 mapSize = new Vector3(10, 10);
		public Material selectedMaterial;
		public Material mouseoverMaterial;
		
		public Hexagon selectedHexagon;
		public Dictionary<Vector2, Hexagon> hexagonDic = new();

		private void Start()
		{
			mapGenerator.GenerateMap();
		}

		public void HexagonInteract(Hexagon hexagon)
		{
			selectedHexagon = hexagon;
		}
	}
	
}

public enum HexagonType
{
	IndustrialCity,
	Slums,
	Wasteland,
	Fertile
}
