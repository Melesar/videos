using System;

namespace App.ContentLoading
{
	public interface IContentLoader
	{
		void LoadAndApplyContent(string url, Action onFinish);
	}
}
