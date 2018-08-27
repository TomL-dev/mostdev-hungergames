using mostdev_hungergames.constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace mostdev_hungergames.controller
{
	class OutputController
	{
		private readonly List<string> summary = new List<string>();

		public void Log(string message)
		{
			if (Constants.EXTENDED_LOG)
			{
				Console.WriteLine(message);
			}
		}
		public void AddToSummary(string message)
		{
			summary.Add(message);
		}
		public void PrintSummary()
		{
			summary.ForEach(entry => Console.WriteLine(entry));
		}
	}
}
