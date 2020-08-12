using System.Collections.Generic;
using UnityEngine;

namespace App.Widgets
{
	[CreateAssetMenu(fileName = nameof(WidgetsPool), menuName = "App/Widgets pool")]
	public class WidgetsPool : ScriptableObject
	{
		[SerializeField] private int _initialCapacity;
		[SerializeField] private ImageWidget _imagePrefab;
		[SerializeField] private VideoWidget _videoPrefab;

		private readonly List<ImageWidget> _imagesPool = new List<ImageWidget>();
		private readonly List<VideoWidget> _videosPool = new List<VideoWidget>();
		
		public ImageWidget GetImage()
		{
			return Get(_imagesPool, _imagePrefab);
		}

		public VideoWidget GetVideo()
		{
			return Get(_videosPool, _videoPrefab);
		}

		public void Init()
		{
			if (!Application.isPlaying)
			{
				return;
			}

			for (int i = 0; i < _initialCapacity; i++)
			{
				ImageWidget imageWidget = SpawnNew(_imagePrefab);
				VideoWidget video = SpawnNew(_videoPrefab);
				
				_imagesPool.Add(imageWidget);
				_videosPool.Add(video);
			}
		}

		private T Get<T>(IList<T> pool, T prefab) where T : AbstractWidget
		{
			T result;
			if (pool.Count > 0)
			{
				result = pool[pool.Count - 1];
				pool.RemoveAt(pool.Count - 1);
			}
			else
			{
				result = SpawnNew(prefab);
			}

			result.gameObject.SetActive(true);
			return result;
		}

		private T SpawnNew<T>(T prefab) where T : AbstractWidget
		{
			T instance = Instantiate(prefab);
			instance.gameObject.SetActive(false);
			return instance;
		}

		private void OnDisable()
		{
			_videosPool.Clear();
			_imagesPool.Clear();
		}
	}
}
