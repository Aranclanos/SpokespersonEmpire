using Managers;
using UnityEngine;

namespace Buildings
{
	public class HealthIndustry : Building
	{
		private readonly float basketOfGoodsAmount = 10;



		public override void Process()
		{
			var amount = basketOfGoodsAmount * Time.deltaTime;
			ResourceManager.instance.basketOfGoods += amount;
			AffectPopulation(-0.1f, -0.25f, 0.1f);
		}
	}
}