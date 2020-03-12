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
					return "Guess what";
				case FeedbackSpot.BetweenImages:
					return "Or";
				case FeedbackSpot.OnSuccess:
					return "Right";
				case FeedbackSpot.OnFailure:
					return "Wrong";
				default:
					throw new ArgumentOutOfRangeException(nameof(spot), spot, null);
			}
		}
	}
}
