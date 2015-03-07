using System;
using System.Collections.Generic;
using MQuicksortLibrary;


namespace MultithreadingQuicksort
{
	class MainClass
	{
		public static int MyCompare(int a, int b)
		{
			if (a<b)
				return -1;
			if (a > b)
				return 1;
			else
				return 0;
		}
		public static void Main (string[] args)
		{
			List<int> array = new List<int> ();
			Random rnd = new Random ();
			for (int i =0; i<20;i++)
				array.Add(rnd.Next(0,100));
			array.QuickSort (MyCompare);
			for(int i =0; i<array.Count;i++)
				Console.Write ("{0} ",array[i]);
		}
	}
}
