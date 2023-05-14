using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "шлях_до_файлу.txt";

        double[] components = ReadComponentsFromFile(filePath);

        double sum = CalculateSum(components);
        Console.WriteLine("Сума компонент файлу: " + sum);

        double product = CalculateProduct(components);
        Console.WriteLine("Добуток компонент файлу: " + product);

        double sumOfSquares = CalculateSumOfSquares(components);
        Console.WriteLine("Сума квадратів компонент файлу: " + sumOfSquares);

        double absSumAndSquareProduct = CalculateAbsoluteValueOfSumAndSquareOfProduct(sum, product);
        Console.WriteLine("Модуль суми і квадрату добутку компонент файлу: " + absSumAndSquareProduct);

        double lastComponent = GetLastComponent(components);
        Console.WriteLine("Остання компонента файлу: " + lastComponent);
    }

    static double[] ReadComponentsFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        double[] components = new double[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            components[i] = double.Parse(lines[i]);
        }

        return components;
    }

    static double CalculateSum(double[] components)
    {
        double sum = 0;

        foreach (double component in components)
        {
            sum += component;
        }

        return sum;
    }

    static double CalculateProduct(double[] components)
    {
        double product = 1;

        foreach (double component in components)
        {
            product *= component;
        }

        return product;
    }

    static double CalculateSumOfSquares(double[] components)
    {
        double sumOfSquares = 0;

        foreach (double component in components)
        {
            sumOfSquares += Math.Pow(component, 2);
        }

        return sumOfSquares;
    }

    static double CalculateAbsoluteValueOfSumAndSquareOfProduct(double sum, double product)
    {
        double absSumAndSquareProduct = Math.Abs(sum) + Math.Pow(product, 2);
        return absSumAndSquareProduct;
    }
    static double GetLastComponent(double[] components)
    {
        return components[components.Length - 1];
    }
}