using App.Data;
using UnityEngine;

namespace App.ContentLoading
{
	[CreateAssetMenu(fileName = nameof(PredefinedContentChoosingStrategy), menuName = "App/Predefined content choosing strategy")]
	public class PredefinedContentChoosingStrategy : AbstractContentChoosingStrategy
	{
		private const int UNINITIALIZED = -1;
		
		[SerializeField] private int _indexFirst;
		[SerializeField] private int _indexSecond;

		private int _currentIndex;
		
		public override ChronologicalContentOptions GetContent()
		{
			if (_currentIndex == UNINITIALIZED)
			{
				_currentIndex = _indexFirst;
			}
			else if (_currentIndex == _indexFirst)
			{
				_currentIndex = _indexSecond;
			}
			else if (_currentIndex == _indexSecond)
			{
				_currentIndex = _indexFirst;
			}

			return ContentLayout.ChronologicalContent[_currentIndex];
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_currentIndex = UNINITIALIZED;
		}
	}
}
