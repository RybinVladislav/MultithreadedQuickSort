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
		static Semaphore pool;
		public static Thread QuickSortThread<T>(this T[] list, int a, int b, CompareDelegate<T> comparer) {
			pool = new Semaphore (10, 10);
			var t = new Thread(() => list.QuickSortRecursive(a, b,comparer));
			t.Start();

			return t;
		}
		public static void QuickSort<T>(this T[] list, CompareDelegate<T> comparer)
		{
			if (comparer == null)
				throw new SortException("No comparer provided");
			int len = list.Length;
			list.QuickSortThread(0,len-1, comparer);

		}
		private static void Swap<T>(ref T a, ref T b)
		{
			T tmp = a;
			a = b;
			b = tmp;
		}
		private static void QuickSortRecursive<T>(this T[] list, int left, int right, CompareDelegate<T> comparer)
		{
			T pivot=list[(left+right)/2];
			int a = left, b = right;
			pool.WaitOne ();
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
					// Swap: which is better?
					Swap (ref list [a], ref list [b]);
					/*T tmp = list[a];
					list[a] =list[b];
					list[b] = tmp;*/

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
			pool.Release ();
		}
	}
}

