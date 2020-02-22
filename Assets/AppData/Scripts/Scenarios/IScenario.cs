using System;

namespace App.Scenarios
{
	public interface IScenario
	{
		void StartScenario(Action onFinish);
	}
}
