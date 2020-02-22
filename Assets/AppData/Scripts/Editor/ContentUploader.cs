using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace App.Editor
{
	public static class ContentUploader
	{
		private const string CONTENT_BUILD_PATH = "ContentBuild";
		private const string REPOSITORY_PATH = "C:\\Content\\Projects\\melesar.github.io";
		private const string LOCAL_DEPLOY_PATH = REPOSITORY_PATH + "\\Content";
		private const string REPOSITORY_BATCH_FILE_NAME = "commit_and_push.bat";
		
		[MenuItem("Tools/Upload all content")]
		public static void UploadAllContent()
		{
			// AddressableAssetSettings.BuildPlayerContent();
			// CopyBundlesToRepository();
			CommitAndPushRepository();
		}

		private static void CopyBundlesToRepository()
		{
			string path = Path.Combine(Application.dataPath, "..", CONTENT_BUILD_PATH);
			foreach (string filePath in Directory.EnumerateFiles(path))
			{
				string fileName = Path.GetFileName(filePath);
				string deployPath = Path.Combine(LOCAL_DEPLOY_PATH, fileName);

				File.Copy(filePath, deployPath);
			}
		}

		private static void CommitAndPushRepository()
		{
			string batchFilePath = Path.Combine(Application.dataPath, "..", REPOSITORY_BATCH_FILE_NAME);
			Process.Start(batchFilePath);
			// var processInfo = new ProcessStartInfo("cmd.exe", "/c " + batchFilePath)
			// {
			// 	CreateNoWindow = true,
			// 	UseShellExecute = false,
			// 	RedirectStandardError = true,
			// 	RedirectStandardOutput = true
			// };
			//
			// Process process = Process.Start(processInfo);
			//
			// process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
			// 	UnityEngine.Debug.Log("output>>" + e.Data);
			// process.BeginOutputReadLine();
			//
			// process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
			// 	UnityEngine.Debug.Log("error>>" + e.Data);
			// process.BeginErrorReadLine();
			//
			// process.WaitForExit();
			//
			// UnityEngine.Debug.Log($"ExitCode: {process.ExitCode}");
			// process.Close();
		}
	}
}
