using App.Data;
using System.Collections.Generic;
using UnityEngine;

namespace App.ContentLoading
{
	
	[CreateAssetMenu(fileName = nameof(RandomContentChoosingStrategy), menuName = "App/Random content choosing strategy")]
	public class RandomContentChoosingStrategy : AbstractContentChoosingStrategy
	{
		public override ChronologicalContentOptions GetContent()
		{
			List<ChronologicalContentOptions> options = ContentLayout.ChronologicalContent;
			return options.Count > 0 ? options[Random.Range(0, options.Count)] : default;
		}
	}
}
