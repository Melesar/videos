using App.Data;
using UnityEngine;

namespace App.ContentLoading
{
	public abstract class AbstractContentChoosingStrategy : ScriptableObject, IContentChoosingStrategy
	{
		[SerializeField] private TextAsset _contentLayoutAsset;
		
		protected ContentLayout ContentLayout
		{
			get
			{
				if (_contentLayout != null)
				{
					return _contentLayout;
				}

				_contentLayout = JsonUtility.FromJson<ContentLayout>(_contentLayoutAsset.text);
				return _contentLayout;
			}
		}

		private ContentLayout _contentLayout;
		
		public abstract ChronologicalContentOptions GetContent();

		protected virtual void OnEnable()
		{
			_contentLayout = null;
		}
	}
}
