using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using UnityEngine.Video;

namespace App.Widgets
{
	public class VideoWidget : AbstractWidget
	{
		[SerializeField] private VideoPlayer _videoPlayer;
		[SerializeField] private RawImage _rawImage;
		
		private RenderTexture _renderTexture;
		
		public override void OnContentLoaded(AsyncOperationHandle handle)
		{
			VideoClip video = handle.Convert<VideoClip>().Result;
			_renderTexture = new RenderTexture((int) video.width, (int) video.height, 24);
			_videoPlayer.clip = video;
			_videoPlayer.source = VideoSource.VideoClip;
			_videoPlayer.renderMode = VideoRenderMode.RenderTexture;
			_videoPlayer.targetTexture = _renderTexture;
			_rawImage.texture = _renderTexture;
			
			RescaleWidget(video);
		}

		private void RescaleWidget(VideoClip video)
		{
			float imageAspect = (float)video.width / video.height;
			bool isWide = imageAspect > 1;
			_videoPlayer.aspectRatio = isWide ? VideoAspectRatio.FitHorizontally : VideoAspectRatio.FitVertically;
			RectTransform.sizeDelta = new Vector2(
				isWide ? MAX_WIDTH : MAX_HEIGHT * imageAspect,	
				isWide ? MAX_WIDTH / imageAspect : MAX_HEIGHT
			);
		}

		private void OnDestroy()
		{
			Destroy(_renderTexture);
		}
	}
}
