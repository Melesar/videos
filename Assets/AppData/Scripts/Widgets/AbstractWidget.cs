using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace App.Widgets
{
	[RequireComponent(typeof(CanvasGroup))]
	public abstract class AbstractWidget : MonoBehaviour
	{
		private CanvasGroup _canvasGroup;
		private RectTransform _rectTransform;
		
		protected const float MAX_WIDTH = 645f;
		protected const float MAX_HEIGHT = 560f;

		public RectTransform RectTransform => _rectTransform ?? (_rectTransform = (RectTransform)transform);

		private Action _onClicked;
		
		public void SetOnClicked(Action onClicked)
		{
			_onClicked = onClicked;
		}

		public Tween Show()
		{
			gameObject.SetActive(true);
			_canvasGroup.alpha = 0f;
			return _canvasGroup.DOFade(1f, 1.5f);
		}

		public void ShowImmediately()
		{
			gameObject.SetActive(true);
			_canvasGroup.alpha = 1f;
		}
		
		public Tween Hide()
		{
			return _canvasGroup.DOFade(0f, 1.5f).OnComplete(() => gameObject.SetActive(false));
		}

		public void Reparent(Transform parent)
		{
			RectTransform.SetParent(parent);
			RectTransform.localPosition = Vector3.zero;
		}
		
		public abstract void OnContentLoaded(AsyncOperationHandle handle);

		private void Awake()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
		}
	}
}
