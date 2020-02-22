using App.Scenarios;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace App
{
	public class Director : MonoBehaviour
	{
		[SerializeField] private List<AbstractScenario> _scenarios;
		[SerializeField] private AbstractScenarioChoosingStrategy _scenarioChoosingStrategy;
		
		private void Start()
		{
			RunScenario();
		}

		private void RunScenario()
		{
			IScenario newScenario = _scenarioChoosingStrategy.GetScenario(_scenarios);
			newScenario.StartScenario(RunScenario);
		}
	}
}
