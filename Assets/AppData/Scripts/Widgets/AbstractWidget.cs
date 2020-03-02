using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace App.Widgets
{
	public abstract class AbstractWidget : MonoBehaviour
	{
		private RectTransform _rectTransform;

		public RectTransform RectTransform => _rectTransform ?? (_rectTransform = (RectTransform)transform);
 		
		public void OnStartLoadingContent()
		{
			
		}
		
		public abstract void OnContentLoaded(AsyncOperationHandle handle);
	}
}
