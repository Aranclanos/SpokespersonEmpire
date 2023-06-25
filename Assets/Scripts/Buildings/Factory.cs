using Managers;
using UnityEngine;

namespace Buildings
{
	public class Factory : Building
	{
		private readonly float refineAmount = 10;



		public override void Process()
		{
			var amount = refineAmount * Time.deltaTime;
			if(ResourceManager.instance.RemoveRawResources(amount))
			{
				ResourceManager.instance.ironSalt += amount;
				AffectPopulation(-1, -0.5f, -0.5f);
			}
		}
	}
}