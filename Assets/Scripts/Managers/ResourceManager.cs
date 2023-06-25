using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Managers
{
	public class ResourceManager : MonoBehaviourSingleton<ResourceManager>
	{
		public float money;
		public float rawResources;
		public float ironSalt;
		public float basketOfGoods;
		public float CableNetworks;
		public float PRToolbox;

		private void Start()
		{
			money = 100000;
		}

		public void AddMoney(float value)
		{
			money += value;
		}

		public bool RemoveMoney(float value)
		{
			if (money >= value)
			{
				money -= value;
				return true;
			}
			return false;
		}
		
		public bool RemoveRawResources(float value)
		{
			if (rawResources >= value)
			{
				rawResources -= value;
				return true;
			}
			return false;
		}

		public bool RemoveIronSalt(float value)
		{
			if (ironSalt >= value)
			{
				ironSalt -= value;
				return true;
			}
			return false;
		}


	}

}
