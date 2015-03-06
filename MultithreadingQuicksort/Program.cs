using System;
using System.Collections.Generic;
using MQuicksortLibrary;


namespace MultithreadingQuicksort
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			List<int> array = new List<int> ();
			Random rnd = new Random ();
			for (int i =0; i<20;i++)
				array.Add(rnd.Next(0,100));
			array.QuickSort ();
			foreach (int elem in array)
				Console.Write ("{0} ",elem);
		}
	}
}
