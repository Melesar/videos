using System;
using System.Collections.Generic;

namespace App.Data
{
	[Serializable]
	public struct ChronologicalContentOptions
	{
		public string Label;
		public long Timestamp;
		public bool IsVideo;
	}
	
	public class ChronologicalComparer : Comparer<ChronologicalContentOptions>
	{
		public override int Compare(ChronologicalContentOptions x, ChronologicalContentOptions y)
		{
			return x.Timestamp.CompareTo(y.Timestamp);
		}
	}
}
