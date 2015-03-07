using System;
using System.Threading;
using System.Collections.Generic;

namespace MQuicksortLibrary
{
	class SortException : ApplicationException
	{		
		public SortException(string message) : base(message) {}
	}

	public static class Sorter
	{
		public delegate int CompareDelegate<T>(T a, T b);
		public static Thread QuickSortThread<T>(this List<T> list, int a, int b, CompareDelegate<T> comparer) {
			var t = new Thread(() => list.QuickSortRecursive(a, b,comparer));
			t.Start();
			return t;
		}
		public static void QuickSort<T>(this List<T> list, CompareDelegate<T> comparer)
		{
			if (comparer == null)
				throw new SortException("No comparer provided");
			int len = list.Count;
			list.QuickSortThread(0,len-1, comparer);

		}
		private static void Swap<T>(T a, T b)
		{
			T tmp = a;
			a = b;
			b = tmp;
		}
		private static void QuickSortRecursive<T>(this List<T> list, int left, int right, CompareDelegate<T> comparer)
		{
			T pivot=list[(left+right)/2];
			int a = left, b = right;
			while (a <= b)
			{
				while (comparer(list[a],pivot)<0) //list[a] *more* than pivot
				{
					a++;
				}
				while (comparer(list[b],pivot)>0) //list[b] *more* than pivot
				{
					b--;
				}
				if (a <= b)
				{
					// Swap
					T tmp = list[a];
					list[a] = list[b];
					list[b] = tmp;

					a++;
					b--;
				}
			}
			if (left < b)
			{
				list.QuickSortThread(left,b, comparer);
			}
			if (a < right)
			{
				list.QuickSortThread(a, right,  comparer);
			}
		}
	}
}

