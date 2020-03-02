using System;

namespace App.Data
{
	[Serializable]
	public struct ChronologicalContentOptions
	{
		public string Label;
		public long Timestamp;
		public bool IsVideo;
	}
}
