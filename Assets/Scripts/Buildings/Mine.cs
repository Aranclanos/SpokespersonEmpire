using Managers;
using UnityEngine;

namespace Buildings
{
	public class Mine : Building
	{
		

		
		public override void Process()
		{
			ResourceManager.instance.rawResources += 100 * Time.deltaTime;
			AffectPopulation(-2, -1, -1);
		}
	}
}