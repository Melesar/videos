using System.Collections.Generic;

namespace App.Scenarios
{
	public interface IScenarioChoosingStrategy
	{
		IScenario GetScenario(IReadOnlyList<IScenario> scenarios);
	}
}
