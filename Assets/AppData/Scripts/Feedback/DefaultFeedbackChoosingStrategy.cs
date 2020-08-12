using System;

namespace App.Feedback
{
	public class DefaultFeedbackChoosingStrategy : IFeedbackChoosingStrategy
	{
		public string GetFeedback(FeedbackSpot spot)
		{
			switch (spot)
			{
				case FeedbackSpot.BeforeImages:
					return "Co było później?";
				case FeedbackSpot.BetweenImages:
					return "Albo";
				case FeedbackSpot.OnSuccess:
					return "Bardzo dobrze!";
				case FeedbackSpot.OnFailure:
					return "Nie! Spróbuj jeszcze ;)";
				default:
					throw new ArgumentOutOfRangeException(nameof(spot), spot, null);
			}
		}
	}
}
