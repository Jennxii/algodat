using System;
using System.Diagnostics;
using System.Threading;

Stopwatch stopWatch = new Stopwatch();
class InsertionSort<T> where T : IComparable<T>
{
    public static void Sort(T[] list)
    {
        for (int j = 1; j < list.Length; j++)
        {
            T key = list[j];

            int i = j - 1;
            while (i >= 0 && list[i].CompareTo(key) > 0)
            {
                list[i + 1] = list[i];
                i--;
            }

            list[i + 1] = key;
        }
    }
}
class Main
{

}
var rand = new Random();
for (int x = 4000; x <= 128000; x += x)
{

    int[] Array = new int[x];
    for (int i = 0; i < Array.Length; i++)
    {
        Array[i] = rand.Next();
    }
    stopWatch.Start();

    Array.InsertionSort();
    stopWatch.Stop();

    long ts = stopWatch.ElapsedMilliseconds;
    long time = 0;
    time += ts;
    long D = time / 5;
    Console.WriteLine($"Array Size {x}: {D} ms");
}






