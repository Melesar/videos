using TMPro;

namespace App.Feedback
{
	public class Feedback : IFeedback
	{
		private readonly TextMeshProUGUI _text;

		public Feedback(TextMeshProUGUI text)
		{
			_text = text;
		}

		public void Post(string feedback)
		{
			_text.text = feedback;
		}
	}
}
