using App.Widgets;
using System;
using UnityEngine;

namespace App.Scenarios
{
	public abstract class AbstractScenario : MonoBehaviour, IScenario
	{
		[SerializeField] private WidgetsPool _widgetsPool;

		protected WidgetsPool WidgetsPool => _widgetsPool;

		public abstract void StartScenario(Action onFinish);
	}
}
