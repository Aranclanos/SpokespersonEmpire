using System.Collections.Generic;
using Units;
using UnityEngine;
using Utilities;

namespace Managers
{
	public class UnitManager : MonoBehaviourSingleton<UnitManager>
	{
		public GameObject unitPrefab;
		public readonly float unitCost = 50000;
		
		private List<Unit> unitList = new List<Unit>();

		public void HireSpokesperson(Hexagon hexagon)
		{
			if (hexagon != null && hexagon.unit == null && ResourceManager.instance.RemoveMoney(unitCost))
			{
				var unitGameobject = Instantiate(unitPrefab);
				var unit = unitGameobject.GetComponent<Unit>();
				var pos = hexagon.transform.position;
				unit.transform.position = new Vector3(pos.x, pos.y, pos.z - 0.6f);
				unit.hexagon = hexagon;
				hexagon.unit = unit;
				unitList.Add(unit);
			}
		}

		public void Update()
		{
			foreach (var unit in unitList)
			{
				unit.hexagon.AffectPublicPerception(5);
			}
		}
	}
}