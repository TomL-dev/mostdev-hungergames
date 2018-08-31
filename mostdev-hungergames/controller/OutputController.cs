using mostdev_hungergames.constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace mostdev_hungergames.controller
{
	static class OutputController
	{
		private static readonly List<String> summary = new List<String>();

		public static void Log(string message, params object[] arguments)
		{
			if (Constants.EXTENDED_LOG)
			{
				Console.WriteLine(message, arguments);
			}
		}
		public static void AddToSummary(string message, params object[] arguments)
		{
			summary.Add(String.Format(message, arguments));
			Log(message, arguments);
		}
		public static void PrintSummary()
		{
			summary.ForEach(entry => Console.WriteLine(entry));
		}
	}
}
