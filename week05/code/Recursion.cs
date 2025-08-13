using System;
using System.Collections.Generic;

public class Recursion
{
    // 1. SumSquaresRecursive
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    // 2. PermutationsChoose
    public static void PermutationsChoose(List<string> results, string letters, int length, string prefix = "")
    {
        if (prefix.Length == length)
        {
            results.Add(prefix);
            return;
        }

        foreach (char c in letters)
        {
            PermutationsChoose(results, letters, length, prefix + c);
        }
    }

    // 3. CountWaysToClimb (with memoization)
    public static decimal CountWaysToClimb(int n, Dictionary<int, decimal> memo = null)
    {
        if (memo == null)
            memo = new Dictionary<int, decimal>();

        if (n < 0)
            return 0;
        if (n == 0)
            return 1;

        if (memo.ContainsKey(n))
            return memo[n];

        decimal ways = CountWaysToClimb(n - 1, memo) + CountWaysToClimb(n - 2, memo);
        memo[n] = ways;
        return ways;
    }

    // 4. WildcardBinary
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('?');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);
    }

    // 5. SolveMaze
    public static void SolveMaze(List<string> results, Maze maze)
    {
        List<(int, int)> currPath = new List<(int, int)>();
        SolveMazeRecursive(results, maze, 0, 0, currPath);
    }

    private static void SolveMazeRecursive(List<string> results, Maze maze, int x, int y, List<(int, int)> currPath)
    {
        // Add current position to path
        currPath.Add((x, y));

        // If we reached the end, add path to results
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Explore all 4 directions
        int[,] moves = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        for (int i = 0; i < 4; i++)
        {
            int newX = x + moves[i, 0];
            int newY = y + moves[i, 1];
            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMazeRecursive(results, maze, newX, newY, currPath);
            }
        }

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);

    }
}
//THANK YOU SIR SORRY FOR THE LATE WORK

