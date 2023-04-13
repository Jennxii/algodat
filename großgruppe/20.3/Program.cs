using AlgoDat;
using System;
using System.Diagnostics;
using System.Threading;

Stopwatch stopWatch = new Stopwatch();

var rand = new Random();

for (int x = 128000; x <= 512000; x += x)
{

    int[] Array = new int[x];
    for (int i = 0; i < Array.Length; i++)
    {
        Array[i] = rand.Next(0, INT_MAX);
    }
    Partition(Array, Array[0 + Array.Length / 2], Array[Array.Length]);

    stopWatch.Start();
    Sort(Array);
    stopWatch.Stop();

    long ts = stopWatch.ElapsedMilliseconds;
    Console.WriteLine($"Array Size {x}: {ts} ms");
}
 class QuickSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] list)
        {
            Sort(list, 0, list.Length - 1);
        }

        private static void Sort(T[] list, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(list, left, right);
                Sort(list, left, pivot - 1);
                Sort(list, pivot + 1, right);
            }
        }

        private static int Partition(T[] list, int left, int right)
        {
            T x = list[right];
            // int pivot = left - 1;
            int pivot = list[right];
            for (int i = left; i < right; i++)
            {
                if (list[i].CompareTo(x) <= 0)
                {
                    pivot++;
                    T tmp = list[i];
                    list[i] = list[pivot];
                    list[pivot] = tmp;
                }
            }

            T tmpPivot = list[pivot + 1];
            list[pivot + 1] = list[right];
            list[right] = tmpPivot;

            return pivot + 1;
        }
    }