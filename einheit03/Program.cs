using System;
using System.Collections.Generic;

public class AoCDay2021Solver
{
    private readonly string inputFile;

    public AoCDay2021Solver(string inputFile)
    {
        this.inputFile = inputFile;
    }

    public List<LineStatus> Analyse()
    {
        var result = new List<LineStatus>();
        string[] lines = System.IO.File.ReadAllLines(inputFile);

        foreach (string line in lines)
        {
            Console.WriteLine($"Line: {line}");
            var status = AnalyseLine(line);
            Console.WriteLine($"Status: {status}\n");
            result.Add(status);
        }

        return result;
    }

    private LineStatus AnalyseLine(string line)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in line)
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                case '<':
                    stack.Push(c);
                    break;
                case ')':
                    if (stack.Count == 0 || stack.Peek() != '(')
                    {
                        return LineStatus.Invalid;
                    }
                    stack.Pop();
                    break;
                case ']':
                    if (stack.Count == 0 || stack.Peek() != '[')
                    {
                        return LineStatus.Invalid;
                    }
                    stack.Pop();
                    break;
                case '}':
                    if (stack.Count == 0 || stack.Peek() != '{')
                    {
                        return LineStatus.Invalid;
                    }
                    stack.Pop();
                    break;
                case '>':
                    if (stack.Count == 0 || stack.Peek() != '<')
                    {
                        return LineStatus.Invalid;
                    }
                    stack.Pop();
                    break;
            }
        }

        return stack.Count == 0 ? LineStatus.Valid : LineStatus.Incomplete;
    }
}

public enum LineStatus
{
    Valid,
    Incomplete,
    Invalid
}

class Program
{
    static void Main(string[] args)
    {
        string inputFile = "input.txt";
        AoCDay2021Solver solver = new AoCDay2021Solver(inputFile);
        List<LineStatus> result = solver.Analyse();
    }
}
