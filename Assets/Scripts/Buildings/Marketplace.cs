using Managers;
using UnityEngine;

namespace Buildings
{
	public class Marketplace : Building
	{
		private readonly float soldAmount = 10;
		private readonly float price = 100;
		

		
		public override void Process()
		{
			var amount = soldAmount * Time.deltaTime;
			if(ResourceManager.instance.RemoveIronSalt(amount))
			{
				ResourceManager.instance.AddMoney(price * amount);
				AffectPopulation(-0.1f, -0.25f, -0.1f);
			}
		}
	}
}