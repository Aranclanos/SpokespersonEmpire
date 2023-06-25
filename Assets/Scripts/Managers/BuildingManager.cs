using Buildings;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace Managers
{
	public class BuildingManager : MonoBehaviourSingleton<BuildingManager>
	{
		public GameObject minePrefab;
		public GameObject factoryPrefab;
		public GameObject marketplacePrefab;
		public GameObject healthIndustryPrefab;
		
		public readonly int mineCost = 10000;
		public readonly int factoryCost = 20000;
		public readonly int marketplaceCost = 30000;
		public readonly int healthIndustryCost = 100000;
		private readonly float processTickRate = 5;
		
		public UnityEvent OnProcess = new UnityEvent();

		private float currentTime;
		
		private void Update()
		{
			OnProcess.Invoke();
		}

		public void CreateMine(Hexagon hexagon)
		{
			CreateBuilding(minePrefab, mineCost, hexagon);
		}
		
		public void CreateFactory(Hexagon hexagon)
		{
			CreateBuilding(factoryPrefab, factoryCost, hexagon);
		}
		
		public void CreateMarketplace(Hexagon hexagon)
		{
			CreateBuilding(marketplacePrefab, marketplaceCost, hexagon);
		}

		public void CreateHealhIndustry(Hexagon hexagon)
		{
			CreateBuilding(healthIndustryPrefab, healthIndustryCost, hexagon);
		}

		private void CreateBuilding(GameObject prefab, int cost, Hexagon hexagon)
		{
			if (hexagon != null && ResourceManager.instance.RemoveMoney(cost))
			{
				var buildingGameobject = Instantiate(prefab);
				var building = buildingGameobject.GetComponent<Building>();
				var randomX = Random.Range(-0.25f, 0.25f);
				var randomY = Random.Range(-0.25f, 0.25f);
				var pos = hexagon.transform.position;
				building.transform.position = new Vector3(pos.x + randomX, pos.y + randomY, pos.z);
				building.Initialize(hexagon);
			}
			
		}

	}
}