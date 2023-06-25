using System;
using TMPro;
using UnityEngine.UI;
using Utilities;

namespace Managers
{
	public class UIManager : MonoBehaviourSingleton<UIManager>
	{
		public Button createMineButton;
		public Button createFactoryButton;
		public Button createMarketplaceButton;
		public Button createHealthIndustryButton;
		public Button hireSpokespersonButton;
		
		
		
		public TextMeshProUGUI moneyText;
		public TextMeshProUGUI ironSaltText;
		public TextMeshProUGUI basketOfGoodsText;
		public TextMeshProUGUI cableNetworksText;
		public TextMeshProUGUI PRToolboxText;
		public TextMeshProUGUI rawResourcesText;

		public void Update()
		{
			var currentMoney = ResourceManager.instance.money;
			var selectedHexagon = MapManager.instance.selectedHexagon;

			createMineButton.interactable = selectedHexagon && currentMoney >= BuildingManager.instance.mineCost;
			createFactoryButton.interactable = selectedHexagon && currentMoney >= BuildingManager.instance.factoryCost;
			createMarketplaceButton.interactable = selectedHexagon && currentMoney >= BuildingManager.instance.marketplaceCost;
			
			if (selectedHexagon && selectedHexagon.hexagonType == HexagonType.Fertile)
			{
				createHealthIndustryButton.interactable = currentMoney >= BuildingManager.instance.healthIndustryCost;
			}
			else
			{
				createHealthIndustryButton.interactable = false;
			}

			if (selectedHexagon && selectedHexagon.unit == null)
			{
				hireSpokespersonButton.interactable = currentMoney >= UnitManager.instance.unitCost;
			}
			else
			{
				hireSpokespersonButton.interactable = false;
			}
			
			moneyText.text = $"{((int)ResourceManager.instance.money).ToString()} Money";
			ironSaltText.text = $"{((int)ResourceManager.instance.ironSalt).ToString()} Iron Salt";
			basketOfGoodsText.text = $"{((int)ResourceManager.instance.basketOfGoods).ToString()} Basket of Goods";
			cableNetworksText.text = $"{((int)ResourceManager.instance.CableNetworks).ToString()} Cable Networks";
			PRToolboxText.text = $"{((int)ResourceManager.instance.PRToolbox).ToString()} PR Toolbox";
			rawResourcesText.text = $"{((int)ResourceManager.instance.rawResources).ToString()} Raw Resources";
		}

		public void CreateMineButton()
		{
			BuildingManager.instance.CreateMine(MapManager.instance.selectedHexagon);
		}
		
		public void CreateFactoryButton()
		{
			BuildingManager.instance.CreateFactory(MapManager.instance.selectedHexagon);
		}
		
		public void CreateMarketplaceButton()
		{
			BuildingManager.instance.CreateMarketplace(MapManager.instance.selectedHexagon);
		}
		
		public void CreateHealthIndustryButton()
		{
			BuildingManager.instance.CreateHealhIndustry(MapManager.instance.selectedHexagon);
		}

		public void HireSpokespersonButton()
		{
			UnitManager.instance.HireSpokesperson(MapManager.instance.selectedHexagon);
		}
	}
}