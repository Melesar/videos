using System;
using UnityEditor;
using UnityEngine;

namespace App.Editor
{
	public static class Utility
	{
		public static long DateField(string label, long timestamp)
		{
			DateTime currentDate = DateTime.FromBinary(timestamp); 
				
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel(label);

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.LabelField("DD", GUILayout.Width(20f));
			int day = EditorGUILayout.IntField(GUIContent.none, currentDate.Day, GUILayout.MinWidth(50f));
			EditorGUILayout.LabelField("MM",GUILayout.Width(30f));
			int month = EditorGUILayout.IntField(GUIContent.none, currentDate.Month, GUILayout.MinWidth(50f));
			EditorGUILayout.LabelField("YYYY", GUILayout.Width(40f));
			int year = EditorGUILayout.IntField(GUIContent.none, currentDate.Year, GUILayout.MinWidth(50f));
			EditorGUILayout.EndHorizontal();

			if (!EditorGUI.EndChangeCheck())
			{
				return timestamp;
			}

			month = Mathf.Clamp(month, 1, 12);
			day = Mathf.Clamp(day, 1, DateTime.DaysInMonth(year, month));
				
			currentDate = new DateTime(year, month, day);
			return currentDate.ToBinary();
		}
		
	}
}
