using System;
using System.Threading;
using System.Collections.Generic;

namespace MQuicksortLibrary
{
	public class SortException : ApplicationException
	{		
		public SortException(string message) : base(message) {}
	}
	public static class Sorter
	{
		public delegate int CompareDelegate<T>(T a, T b);
		public static void QuickSort<T>(this List<T> list, CompareDelegate<T> comparer)
		{
			if (comparer == null)
				throw new SortException("No comparer provided");
			int len = list.Count;
			list.QuickSortRecursive(0,len-1, comparer);
		}
		private static void QuickSortRecursive<T>(this List<T> list, int left, int right, CompareDelegate<T> comparer)
		{
			if (left < right)
				new Thread (list.Partition(left,right,comparer)).Start();
		}
		private static void Partition<T>(this List<T> list, int left, int right, CompareDelegate<T> comparer)
		{
			Console.WriteLine(default(int));
		}
	}
}

