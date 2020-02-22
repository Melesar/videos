using System.Collections.Generic;
using UnityEngine;

namespace App.Scenarios
{
	[CreateAssetMenu(fileName = nameof(RandomScenarioChoosingStrategy), menuName = "App/Scenario choosing strategy")]
	public class RandomScenarioChoosingStrategy : AbstractScenarioChoosingStrategy
	{
		public override IScenario GetScenario(IReadOnlyList<IScenario> scenarios)
		{
			return scenarios.Count > 0 ? scenarios[Random.Range(0, scenarios.Count)] : null;
		}
	}
}
