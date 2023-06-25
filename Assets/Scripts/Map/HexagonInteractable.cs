using System;
using Managers;
using UnityEngine;

namespace Map
{
	public class HexagonInteractable : MonoBehaviour
	{
		public Hexagon hexagon;
		
		void OnMouseOver()
		{
			if (Input.GetMouseButton(0))
			{
				if (MapManager.instance.selectedHexagon && MapManager.instance.selectedHexagon != hexagon)
				{
					MapManager.instance.selectedHexagon.selectorMeshRenderer.enabled = false;
				}
				hexagon.selectorMeshRenderer.material = MapManager.instance.selectedMaterial;
				MapManager.instance.HexagonInteract(hexagon);
			}
		}

		private void OnMouseEnter()
		{
			hexagon.selectorMeshRenderer.enabled = true;
			if (MapManager.instance.selectedHexagon == hexagon)
			{
				hexagon.selectorMeshRenderer.material = MapManager.instance.selectedMaterial;
			}
			else
			{
				hexagon.selectorMeshRenderer.material = MapManager.instance.mouseoverMaterial;
			}
		}

		private void OnMouseExit()
		{
			if (MapManager.instance.selectedHexagon != hexagon)
			{
				hexagon.selectorMeshRenderer.enabled = false;
			}
		}
	}
}