using AlgoDat;
using System;
using System.Diagnostics;
using System.Threading;

Stopwatch stopWatch = new Stopwatch();
var rand = new Random();
for (int x = 4000; x <= 512000; x += x)
{
    int[] Array = new int[x];
    for (int i = 0; i < Array.Length; i++)
    {
        Array[i] = rand.Next();
    }
    for (int u = 8; u <= 64; u += u)
    {
        stopWatch.Start();
        Array.CutOff(u);
        Sort(Array);
        stopWatch.Stop();
    }
    long ts = stopWatch.ElapsedMilliseconds;
    Console.WriteLine($"Array Size {x}: {ts} ms");
}

public class AlgoDatSort<T> where T : IComparable<T>
{
    public int Cutoff { get; set; }

    public void Sort(T[] list)
    {

        foreach (T x in list)
        {
            if (list[x].CompareTo(Cutoff) <= 0)
            {
                list.InsertionSort();
            }
            else
            {
                list.MergeSort();
            }
        }
    }

    public GetArray() { }


}