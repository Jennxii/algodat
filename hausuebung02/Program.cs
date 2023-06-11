using System.Collections;
using System;
using System.Diagnostics;
using AlgoDat;



TreeDictionary<int, string> treedic = new TreeDictionary<int, string>();
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
for (int i = 0; i < 10000; i++)
{
    treedic.Add(i, $"Value {i}");
}
stopwatch.Stop();
Console.WriteLine($"Hinzufügen von 10.000 Einträgen: {stopwatch.Elapsed}");


stopwatch.Reset();
stopwatch.Start();
for (int i = 0; i < 10000; i++)
{
    string value = treedic.Get(i);
}
stopwatch.Stop();
Console.WriteLine($"Suchen von 10.000 Einträgen: {stopwatch.Elapsed}");

HashTable<int> hashish = new HashTable<int>();
stopwatch.Reset();

stopwatch.Start();
for (int i = 0; i < 10000; i++)
{
    hashish.Add(i);
}
stopwatch.Stop();
Console.WriteLine($"Hinzufügen von 10.000 hashish: {stopwatch.Elapsed}");


stopwatch.Reset();
stopwatch.Start();
for (int i = 0; i < 10000; i++)
{
    hashish.Search(i);
}
stopwatch.Stop();
Console.WriteLine($"Suchen von 10.000 hashish: {stopwatch.Elapsed}");
