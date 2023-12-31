using UnityEngine;

namespace Utilities
{
	public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		public static T instance;

		/// <summary>
		/// If you override this then make sure you call base.Awake()
		/// </summary>
		public virtual void Awake()
		{
			if (instance == null)
			{
				instance = this as T;
				transform.SetParent(null);
				//DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}

		/// <summary>
		/// If you override this then make sure you call base.OnDestroy() somewhere in your OnDestroy code.
		/// </summary>
		protected void OnDestroy()
		{
			if (instance == this)
			{
				instance = null;
			}
		}
	}
}