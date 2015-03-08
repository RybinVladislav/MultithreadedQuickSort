using System;
using System.Collections.Generic;
using System.Threading;
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
			int[] array = new int[500000];
			Random rnd = new Random ();
			for (int i =0; i<array.Length;i++)
				array[i]=rnd.Next(0,1000000);
			DateTime start = DateTime.Now;
			array.QuickSort (MyCompare);
			DateTime finish = DateTime.Now;
			/*for(int i =0; i<array.Length;i++)
				Console.Write ("{0} ",array[i]);*/
			Console.WriteLine ("\ndone in {0} s",(finish-start).TotalSeconds);
		}
	}
}
