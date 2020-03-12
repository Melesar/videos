namespace App.Feedback
{
	public interface IFeedbackChoosingStrategy
	{
		string GetFeedback(FeedbackSpot spot);
	}
}
