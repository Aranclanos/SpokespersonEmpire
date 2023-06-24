using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Managers
{
	public class ResourceManager : MonoBehaviourSingleton<ResourceManager>
	{
		public int money;
		public int ironSalt;
		public int basketOfGoods;
		public int CableNetworks;
		public int PRToolbox;

		public void AddMoney(int value)
		{
			money += value;
		}

		public bool RemoveMoney(int value)
		{
			if (money >= value)
			{
				money -= value;
				return true;
			}
			return false;
		}


	}

}
