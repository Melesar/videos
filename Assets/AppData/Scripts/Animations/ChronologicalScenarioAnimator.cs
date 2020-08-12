using App.ContentLoading;
using App.Data;
using App.Feedback;
using App.Widgets;
using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace App.Animations
{
	public class ChronologicalScenarioAnimator : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _feedbackText;
		[SerializeField] private ContentLoader _loader;
		[SerializeField] private Transform _mainParent;
		[SerializeField] private CanvasGroup _canvasGroup;
		[SerializeField] private Transform _topParent;
		[SerializeField] private Transform _bottomParent;

		private IFeedback _feedback;
		private DecisionStatus _decisionStatus;
		
		public void StartAnimation(ChronologicalAnimationContext context)
		{
			StartCoroutine(AnimationCoroutine(context));
		}

		private IEnumerator AnimationCoroutine(ChronologicalAnimationContext context)
		{
			_decisionStatus = DecisionStatus.None;
			
			bool isFirstOptionRight = Random.value > 0.5f;
			ChronologicalContentOptions first = isFirstOptionRight ? context.RightOption : context.WrongOption;
			ChronologicalContentOptions second = isFirstOptionRight ? context.WrongOption : context.RightOption;
			AbstractWidget widgetFirst = _loader.LoadContentAndSpawnWidget(first);
			AbstractWidget widgetSecond = _loader.LoadContentAndSpawnWidget(second);

			yield return StartCoroutine(ShowFeedback(context, FeedbackSpot.BeforeImages));

			yield return StartCoroutine(ShowMain(widgetFirst));
			
			yield return StartCoroutine(ShowFeedback(context, FeedbackSpot.BetweenImages));

			yield return StartCoroutine(ShowMain(widgetSecond));

			ArrangeWidgets(widgetFirst, widgetSecond);

			yield return StartCoroutine(ShowWidgets());

			AbstractWidget rightWidget = isFirstOptionRight ? widgetFirst : widgetSecond;
			AbstractWidget wrongWidget = isFirstOptionRight ? widgetSecond : widgetFirst;
			rightWidget.SetOnClicked(() => _decisionStatus = DecisionStatus.Right);
			wrongWidget.SetOnClicked(() => _decisionStatus = DecisionStatus.Wrong);

			yield return new WaitWhile(() => _decisionStatus == DecisionStatus.None);

			FeedbackSpot feedback = _decisionStatus == DecisionStatus.Right ? FeedbackSpot.OnSuccess : FeedbackSpot.OnFailure;
			widgetFirst.HideImmediately();
			widgetSecond.HideImmediately();
			yield return StartCoroutine(ShowFeedback(context, feedback));
			context.OnAnimationFinish?.Invoke();
		}

		private IEnumerator ShowFeedback(ChronologicalAnimationContext context, FeedbackSpot spot)
		{
			context.FeedbackCommand.Execute(_feedback, spot);
			_feedbackText.gameObject.SetActive(true);
			yield return _feedbackText.DOFade(1f, 1f).WaitForCompletion();
			yield return new WaitForSeconds(2f);
			yield return _feedbackText.DOFade(0f, 0.4f).WaitForCompletion();
			_feedbackText.gameObject.SetActive(false);
		}

		private IEnumerator ShowMain(AbstractWidget widget)
		{
			widget.Reparent(_mainParent);
			
			yield return widget.Show().WaitForCompletion();
			yield return new WaitForSeconds(3f);
			yield return widget.Hide().WaitForCompletion();
		}

		private IEnumerator ShowWidgets()
		{
			yield return _canvasGroup.DOFade(1f, 1.5f).WaitForCompletion();
		}

		private void ArrangeWidgets(AbstractWidget widgetFirst, AbstractWidget widgetSecond)
		{
			_canvasGroup.alpha = 0f;
			widgetFirst.Reparent(_topParent);
			widgetSecond.Reparent(_bottomParent);
			widgetFirst.ShowImmediately();
			widgetSecond.ShowImmediately();
		}

		private void Awake()
		{
			_feedback = new Feedback.Feedback(_feedbackText);
		}

		private enum DecisionStatus
		{
			None,
			Right,
			Wrong
		}
	}
}
