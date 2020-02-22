using App.Data;
using System;
using UnityEditor;
using UnityEngine;

namespace App.Editor
{
	public class ContentImportWindow : EditorWindow
	{
		[MenuItem("Tools/Content importer")]
		public static void OpenWindow()
		{
			GetWindow<ContentImportWindow>().titleContent = new GUIContent("Content importer");
		}

		private readonly ContentImporter _importer = new ContentImporter();

		private string _currentAssetPath;
		private ContentType _currentContentType;

		private ChronologicalContentOptions _chronologicalContent;

		private void OnGUI()
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.TextField("File to import", _currentAssetPath);
			if (GUILayout.Button("Choose", EditorStyles.miniButton, GUILayout.Width(70f)))
			{
				_currentAssetPath = EditorUtility.OpenFilePanel("Choose file to import", "", "png,jpg,mp4");
			}
			EditorGUILayout.EndHorizontal();

			Action buttonAction = null;
			_currentContentType = (ContentType) EditorGUILayout.EnumPopup("Content type", _currentContentType);
			switch (_currentContentType)
			{
				case ContentType.Chronological:
					DrawChronologicalContent();
					buttonAction = () => _importer.ImportAsset(_currentAssetPath, _chronologicalContent);
					break;
			}
			
			GUILayout.FlexibleSpace();

			EditorGUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Import asset"))
			{
				buttonAction?.Invoke();
			}
			EditorGUILayout.EndHorizontal();
		}

		private void DrawChronologicalContent()
		{
			_chronologicalContent.Label = EditorGUILayout.TextField("Asset label", _chronologicalContent.Label);
			_chronologicalContent.Timestamp = Utility.DateField("Date", _chronologicalContent.Timestamp);
		}
	}
}
