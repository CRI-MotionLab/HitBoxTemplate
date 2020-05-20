using UnityEngine;
using System.IO;

namespace CRI.HitBoxTemplate.Example
{
	public static class DataStorage
	{
		private static string reportDirectoryName = "Reports";
		private static string reportFileName = "report";
		private static string reportSeparator = ",";
		private static string[] reportHeaders = new string[3]{
			"BPM",
			"Angle",
			"Reaction Time"
		};
		private static string timeStampHeader = "Time stamp";

		public static void AppendToReport(string[] strings)
		{
			VerifyFile();
			using (StreamWriter sw = File.AppendText(GetFilePath()))
			{
				string finalString = "";
				finalString += GetTimeStamp();
				for (int i = 0; i < strings.Length; i++)
				{
					finalString += reportSeparator;
					finalString += strings[i];
				}
				sw.WriteLine(finalString);
			}
		}

		public static void AppendSeparatorToReport()
		{
			VerifyFile();
			using (StreamWriter sw = File.AppendText(GetFilePath()))
			{
				string finalString = "";
				sw.WriteLine(finalString);
			}
		}

		public static void CreateReport()
		{
			VerifyDirectory();

			using (StreamWriter sw = File.CreateText(GetFilePath()))
			{
				string finalString = "";
				finalString += timeStampHeader;
				for (int i = 0; i < reportHeaders.Length; i++)
				{
					finalString += reportSeparator;
					finalString += reportHeaders[i];
				}
				sw.WriteLine(finalString);
			}
		}

		static void VerifyDirectory()
		{
			string dir = GetDirectoryPath();
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
		}

		static void VerifyFile()
		{
			VerifyDirectory();
			string file = GetFilePath();
			if (!File.Exists(file))
			{
				CreateReport();
			}
		}

		static string GetDirectoryPath()
		{
			return Application.dataPath + "/" + reportDirectoryName;
		}

		static string GetFilePath()
		{
			return GetDirectoryPath() + "/" + reportFileName + ".csv";
		}

		static string GetTimeStamp()
		{
			return System.DateTime.UtcNow.ToString();
		}

	}
}
