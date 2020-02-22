using System;
using UnityEngine;
using UnityEngine.UI;

namespace App.ContentLoading
{
	public class ImageLoader : AbstractContentLoader
	{
		[SerializeField] private RawImage _uiImage;
		

		public override void LoadAndApplyContent(string url, Action onFinish)
		{
			
		}
	}
}
