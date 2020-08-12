using App.Animations;
using App.ContentLoading;
using App.Data;
using App.Feedback;
using App.Widgets;
using System;
using UnityEngine;

namespace App.Scenarios
{
	public class ChronologyScenario : AbstractScenario
	{
		[SerializeField] private int _numSteps;
		[SerializeField] private AbstractContentChoosingStrategy _contentChoosingStrategy;
		[SerializeField] private ChronologicalScenarioAnimator _animator;

		private IFeedbackChoosingStrategy _feedbackChoosingStrategy;
		private ChronologicalComparer _comparer;
		private SubmitFeedbackCommand _feedbackCommand;
		
		public override void StartScenario(Action onFinish)
		{
			ChronologicalContentOptions content1 = _contentChoosingStrategy.GetContent();
			ChronologicalContentOptions content2 = _contentChoosingStrategy.GetContent();
			bool comparison = _comparer.Compare(content1, content2) > 0;
			ChronologicalContentOptions correct = comparison
				? content1
				: content2;
			ChronologicalContentOptions wrong = comparison
				? content2
				: content1;
			
			_animator.StartAnimation(new ChronologicalAnimationContext
			{
				RightOption = correct,
				WrongOption = wrong,
				FeedbackCommand = _feedbackCommand,
				OnAnimationFinish = onFinish
			});
		}

		private void Awake()
		{
			_feedbackChoosingStrategy = new DefaultFeedbackChoosingStrategy();
			_comparer = new ChronologicalComparer();
			_feedbackCommand = new SubmitFeedbackCommand(_feedbackChoosingStrategy);
		}

		private class SubmitFeedbackCommand : ICommand<IFeedback, FeedbackSpot>
		{
			private readonly IFeedbackChoosingStrategy _strategy;

			public SubmitFeedbackCommand(IFeedbackChoosingStrategy strategy)
			{
				_strategy = strategy;
			}

			public void Execute(IFeedback feedback, FeedbackSpot payload)
			{
				feedback.Post(_strategy.GetFeedback(payload));
			}
		}
	}
}
