using App.ContentLoading;
using System;
using UnityEngine;

namespace App.Scenarios
{
	public class ChronologyScenario : AbstractScenario
	{
		[SerializeField] private int _numSteps;
		[SerializeField] private ContentLoader _loader;
		
		public override void StartScenario(Action onFinish)
		{
			_loader.LoadContentAndSpawnWidget();
		}
	}
}
