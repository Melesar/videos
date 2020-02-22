using App.Data;
using System;
using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace App.Editor
{
	public class ContentImporter
	{
		private const string CONTENT_FOLDER = "Assets/AppData/Content";
		private const string CONTENT_LAYOUT_PATH = "Assets/AppData/Settings/ContentLayout.bytes";

		private AddressableAssetSettings _settings;

		private AddressableAssetSettings AddressableAssetSettings
		{
			get
			{
				if (_settings == null)
				{
					_settings = Resources.FindObjectsOfTypeAll<AddressableAssetSettings>()[0];
				}

				return _settings;
			}
		}
		
		public void ImportAsset<T>(string assetPath, T assetOptions)
		{
			switch (assetOptions)
			{
				case ChronologicalContentOptions chronological:
					ImportChronological(assetPath, chronological);
					break;
				default:
					throw new ArgumentException($"Invalid type {typeof(T)}", nameof(assetOptions));
			}
		}

		private void ImportChronological(string assetPath, ChronologicalContentOptions options)
		{
			string importedFilePath = ImportAssetToProject(assetPath, options.Label);
			AddAssetToAddressables(importedFilePath, options.Label);

			ContentLayout layout = GetOrCreateContentLayout();
			layout.ChronologicalContent.Add(options);
			string json = JsonUtility.ToJson(layout);

			File.WriteAllText(CONTENT_LAYOUT_PATH, json);
			AssetDatabase.ImportAsset(CONTENT_LAYOUT_PATH);
			AssetDatabase.Refresh();
		}

		private string ImportAssetToProject(string assetPath, string label)
		{
			var fileInfo = new FileInfo(assetPath);
			if (!fileInfo.Exists)
			{
				throw new FileNotFoundException("File to import is not found", assetPath);
			}

			if (string.IsNullOrEmpty(label))
			{
				throw new ArgumentException("Label must be specified");
			}
			
			string extension = fileInfo.Extension;
			string newFilePath = AssetDatabase.GenerateUniqueAssetPath($"{CONTENT_FOLDER}/{label}{extension}");
			FileUtil.CopyFileOrDirectory(assetPath, newFilePath);
			AssetDatabase.ImportAsset(newFilePath);

			return newFilePath;
		}

		private void AddAssetToAddressables(string assetPath, string address)
		{
			AddressableAssetGroup defaultGroup = AddressableAssetSettings.DefaultGroup;
			AddressableAssetEntry assetEntry = AddressableAssetSettings
				.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(assetPath), defaultGroup);
			assetEntry.SetAddress(address);
		}

		private ContentLayout GetOrCreateContentLayout()
		{
			var layoutAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(CONTENT_LAYOUT_PATH);
			return layoutAsset != null 
				? JsonUtility.FromJson<ContentLayout>(layoutAsset.text) 
				: new ContentLayout();
		}
	}
}
