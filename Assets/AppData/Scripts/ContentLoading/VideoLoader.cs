using System;
using UnityEngine;
using UnityEngine.Video;

namespace App.ContentLoading
{
	public class VideoLoader : AbstractContentLoader
	{
		[SerializeField] private VideoPlayer _videoPlayer;
		
		public override void LoadAndApplyContent(string url, Action onFinish)
		{
		}
	}
}
