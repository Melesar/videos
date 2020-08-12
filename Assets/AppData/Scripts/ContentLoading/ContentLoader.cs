using App.Data;
using App.Widgets;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Video;

namespace App.ContentLoading
{
	public class ContentLoader : MonoBehaviour
	{
		[SerializeField] private WidgetsPool _widgetsPool;

		public AbstractWidget LoadContentAndSpawnWidget(ChronologicalContentOptions contentOptions)
		{
			AbstractWidget widget = contentOptions.IsVideo ? (AbstractWidget) _widgetsPool.GetVideo() : _widgetsPool.GetImage();
			widget.gameObject.SetActive(false);
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

		private void Awake()
		{
			_widgetsPool.Init();
		}
	}
}
