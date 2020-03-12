using System;
using UnityEngine;

namespace App.Scenarios
{
	public abstract class AbstractScenario : MonoBehaviour, IScenario
	{
		public abstract void StartScenario(Action onFinish);
	}
}
