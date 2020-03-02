using App.Data;
using App.Widgets;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Video;

namespace App.ContentLoading
{
	public class ContentLoader : MonoBehaviour
	{
		[SerializeField] private WidgetsPool _widgetsPool;
		[SerializeField] private AbstractContentChoosingStrategy _contentChoosingStrategy;

		public AbstractWidget LoadContentAndSpawnWidget()
		{
			ChronologicalContentOptions contentOptions = _contentChoosingStrategy.GetContent();
			AbstractWidget widget = contentOptions.IsVideo ? (AbstractWidget) _widgetsPool.GetVideo() : _widgetsPool.GetImage();
			widget.OnStartLoadingContent();
			if (contentOptions.IsVideo)
			{
				Addressables.LoadAssetAsync<VideoClip>(contentOptions.Label).CompletedTypeless += widget.OnContentLoaded;
			}
			else
			{
				Addressables.LoadAssetAsync<Texture2D>(contentOptions.Label).CompletedTypeless += widget.OnContentLoaded;
			}

			return widget;
		}
		
		
	}
}
