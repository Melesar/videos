using App.Data;
using App.Feedback;
using System;

namespace App.Animations
{
	public class ChronologicalAnimationContext
	{
		public ChronologicalContentOptions RightOption { get; set; }
		public ChronologicalContentOptions WrongOption { get; set; }
		public ICommand<IFeedback, FeedbackSpot> FeedbackCommand { get; set; }
		public Action OnAnimationFinish { get; set; }
	}
}
