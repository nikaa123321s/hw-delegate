using System;
using System.Collections.Generic;

// Helper class with LINQ-like methods using IEnumerable, Generics, and Delegates
public static class EnumerableExtensions
{
    /// <summary>
    /// Filters a collection and returns only elements that satisfy the given condition.
    /// </summary>
    public static IEnumerable<T> Where<T>(IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (T item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Returns the first element that matches the condition.
    /// If not found, returns the default value (null, 0, false, etc.).
    /// </summary>
    public static T FirstOrDefault<T>(IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (T item in source)
        {
            if (predicate(item))
            {
                return item;
            }
        }
        return default(T);
    }

    /// <summary>
    /// Checks if there is at least one element that satisfies the condition.
    /// Returns true or false.
    /// </summary>
    public static bool Any<T>(IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (T item in source)
        {
            if (predicate(item))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Checks if all elements satisfy the given condition.
    /// Returns true or false.
    /// </summary>
    public static bool All<T>(IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (T item in source)
        {
            if (!predicate(item))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Counts the number of elements that satisfy the condition.
    /// </summary>
    public static int Count<T>(IEnumerable<T> source, Func<T, bool> predicate)
    {
        int count = 0;
        foreach (T item in source)
        {
            if (predicate(item))
            {
                count++;
            }
        }
        return count;
    }
}

// Example usage
class Program
{
    static void Main()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Where: Filter even numbers
        Console.WriteLine("Where (even numbers):");
        foreach (var num in EnumerableExtensions.Where(numbers, x => x % 2 == 0))
        {
            Console.Write(num + " ");
        }
        Console.WriteLine("\n");

        // FirstOrDefault: Find first number greater than 5
        Console.WriteLine("FirstOrDefault (first number > 5):");
        var firstGreaterThan5 = EnumerableExtensions.FirstOrDefault(numbers, x => x > 5);
        Console.WriteLine(firstGreaterThan5);
        Console.WriteLine();

        // Any: Check if any number is greater than 8
        Console.WriteLine("Any (is there a number > 8?):");
        bool hasGreaterThan8 = EnumerableExtensions.Any(numbers, x => x > 8);
        Console.WriteLine(hasGreaterThan8);
        Console.WriteLine();

        // All: Check if all numbers are positive
        Console.WriteLine("All (all positive?):");
        bool allPositive = EnumerableExtensions.All(numbers, x => x > 0);
        Console.WriteLine(allPositive);
        Console.WriteLine();

        // Count: Count numbers greater than 5
        Console.WriteLine("Count (numbers > 5):");
        int countGreaterThan5 = EnumerableExtensions.Count(numbers, x => x > 5);
        Console.WriteLine(countGreaterThan5);
    }
}
