using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;


namespace Buildings
{
	public class Building : MonoBehaviour
	{
		protected Hexagon hexagon;
		protected float morale;
		protected float health;
		protected float workers;

		private readonly float workerObtainEffect = 0.1f;
		
		public virtual void Process()
		{

		}

		public virtual void Initialize(Hexagon hexagonTarget)
		{
			hexagon = hexagonTarget;
			hexagon.AddBuilding(this);
			BuildingManager.instance.OnProcess.AddListener(Process);
		}

		public void ObtainWorker()
		{
			workers++;
			hexagon.AffectPublicPerception(-workerObtainEffect);
			health += 10;
		}

		private void WorkerDeath()
		{
			ObtainWorker();
		}

		protected void AffectPopulation(float moraleEffect, float healthEffect, float perceptionEffect)
		{
			moraleEffect += moraleEffect * Time.deltaTime;
			if (moraleEffect < 0)
			{
				moraleEffect = 0;
			}

			health += healthEffect * Time.deltaTime;
			if (health < 0)
			{
				WorkerDeath();
			}

			hexagon.AffectPublicPerception(perceptionEffect);
		}

		private void OnDestroy()
		{
			hexagon.RemoveBuilding(this);
		}
	}

}
