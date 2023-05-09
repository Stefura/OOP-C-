using System;

public static class ArrayExtensions
{
    public static void SortAscending(this int[] array)
    {
        Array.Sort(array);
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 5, 2, 7, 1, 6, 10, 8, 3 };

        Console.WriteLine("До сортування:");
        PrintArray(numbers);

        numbers.SortAscending();

        Console.WriteLine("\nПісля сортування:");
        PrintArray(numbers);
    }

    static void PrintArray(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}
