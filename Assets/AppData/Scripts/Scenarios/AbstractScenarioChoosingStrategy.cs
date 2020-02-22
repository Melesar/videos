using System.Collections.Generic;
using UnityEngine;

namespace App.Scenarios
{
	public abstract class AbstractScenarioChoosingStrategy : ScriptableObject, IScenarioChoosingStrategy
	{
		public abstract IScenario GetScenario(IReadOnlyList<IScenario> scenarios);
	}
}
