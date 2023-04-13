using System;
using System.Diagnostics;
using System.Threading;

Stopwatch stopWatch = new Stopwatch();

void Sort(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        int minPos = i;
        for (int j = i; j < numbers.Length; j++)
        {
            if (numbers[j] < numbers[minPos])
            {
                minPos = j;
            }
        }
        int tmp = numbers[i];
        numbers[i] = numbers[minPos];
        numbers[minPos] = tmp;
    }
}

var rand = new Random();
for (int x = 4000; x <= 256000; x += x)
{
    for (int u = 0; u < 5; u++)
    {
        int[] Array = new int[x];
        for (int i = 0; i < Array.Length; i++)
        {
            Array[i] = rand.Next();
        }
        stopWatch.Start();
        Sort(Array);
        stopWatch.Stop();
    }
    long ts = stopWatch.ElapsedMilliseconds;
    long time = 0;
    time += ts;
    long D = time / 5;
    Console.WriteLine($"Array Size {x}: {D} ms");
}






