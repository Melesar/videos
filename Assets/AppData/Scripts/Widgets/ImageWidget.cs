
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace App.Widgets
{
	public class ImageWidget : AbstractWidget
	{
		[SerializeField] private RawImage _image;
		
		
		public override void OnContentLoaded(AsyncOperationHandle handle)
		{
			Texture2D texture = handle.Convert<Texture2D>().Result;
			_image.texture = texture;
		}
	}
}
