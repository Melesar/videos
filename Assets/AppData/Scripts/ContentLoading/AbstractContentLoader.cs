using System;
using UnityEngine;

namespace App.ContentLoading
{
	public abstract class AbstractContentLoader : MonoBehaviour, IContentLoader
	{
		public abstract void LoadAndApplyContent(string url, Action onFinish);
	}
}
