using System;
using System.Collections.Generic;

public static class Recursion
{
    /// ################
    /// # Problem 1    #
    /// ################
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0; // base case
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// ################
    /// # Problem 2    #
    /// ################
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    /// ################
    /// # Problem 3    #
    /// ################
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        remember ??= new Dictionary<int, decimal>();

        if (remember.TryGetValue(s, out var cached))
            return cached;

        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// ################
    /// # Problem 4    #
    /// ################
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int star = pattern.IndexOf('*');
        if (star == -1)
        {
            results.Add(pattern);
            return;
        }

        string left = pattern[..star];
        string right = pattern[(star + 1)..];

        WildcardBinary(left + "0" + right, results);
        WildcardBinary(left + "1" + right, results);
    }

    /// ################
    /// # Problem 5    #
    /// ################
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        currPath ??= new List<(int, int)>();

        // Reject revisits
        if (currPath.Contains((x, y)))
            return;

        // Check if move is valid (Maze method only takes x, y)
        if (!maze.IsValidMove(x, y))
            return;

        // Choose
        currPath.Add((x, y));

        // Check for goal
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Explore
        SolveMaze(results, maze, x + 1, y, currPath); // right
        SolveMaze(results, maze, x - 1, y, currPath); // left
        SolveMaze(results, maze, x, y + 1, currPath); // down
        SolveMaze(results, maze, x, y - 1, currPath); // up

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}
