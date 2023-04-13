using System.Diagnostics;

using AlgoDat;

int arraySize = 256000;
int cutOff = 16;

// Generate array
int[] array = new int[arraySize];
Random rnd = new();

for (int i = 0; i < array.Length; i++)
{
    array[i] = rnd.Next();
}

// Copy array for measure
int[] array2 = new int[arraySize];
Array.Copy(array, array2, arraySize);

// Stopwatch
Stopwatch sw = new();

// Try out the sorter
AlgoDatSort<int> sorter = new();
sorter.Cutoff = cutOff;

// Measure time of first array
sw.Start();
sorter.Sort(array);
sw.Stop();
double time = sw.Elapsed.TotalMilliseconds;

// Measure time of second array
sw.Restart();
MergeSort<int>.Sort(array2);
sw.Stop();
double time2 = sw.Elapsed.TotalMilliseconds;

Console.WriteLine("AlgoDatSort: " + time);
Console.WriteLine("MergeSort: " + time2);

