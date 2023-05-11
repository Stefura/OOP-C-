using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Шлях до файлу
        string filePath = "шлях_до_файлу.txt";

        // Отримуємо масив компонент файлу
        double[] components = ReadComponentsFromFile(filePath);

        // Задані операції над масивом компонент

        // 1) Сума компонент файлу f
        double sum = CalculateSum(components);
        Console.WriteLine("Сума компонент файлу: " + sum);

        // 2) Добуток компонент файлу f
        double product = CalculateProduct(components);
        Console.WriteLine("Добуток компонент файлу: " + product);

        // 3) Сума квадратів компонент файлу f
        double sumOfSquares = CalculateSumOfSquares(components);
        Console.WriteLine("Сума квадратів компонент файлу: " + sumOfSquares);

        // 4) Модуль суми і квадрат добутку компонент файлу f
        double absSumAndSquareProduct = CalculateAbsoluteValueOfSumAndSquareOfProduct(sum, product);
        Console.WriteLine("Модуль суми і квадрату добутку компонент файлу: " + absSumAndSquareProduct);

        // 5) Остання компонента файлу
        double lastComponent = GetLastComponent(components);
        Console.WriteLine("Остання компонента файлу: " + lastComponent);
    }

    // Метод для читання компонент з файлу
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

    // Метод для розрахунку суми компонент
    static double CalculateSum(double[] components)
    {
        double sum = 0;

        foreach (double component in components)
        {
            sum += component;
        }

        return sum;
    }

    // Метод для розрахунку добутку компонент
    static double CalculateProduct(double[] components)
    {
        double product = 1;

        foreach (double component in components)
        {
            product *= component;
        }

        return product;
    }

    // Метод для розрахунку суми квадратів компонент
    static double CalculateSumOfSquares(double[] components)
    {
        double sumOfSquares = 0;

        foreach (double component in components)
        {
            sumOfSquares += Math.Pow(component, 2);
        }

        return sumOfSquares;
    }

    // Метод для розрахунку модуля суми і квадрату добутку компонент
    static double CalculateAbsoluteValueOfSumAndSquareOfProduct(double sum, double product)
    {
        double absSumAndSquareProduct = Math.Abs(sum) + Math.Pow(product, 2);
        return absSumAndSquareProduct;
    }
    // Метод для отримання останньої компоненти файлу
    static double GetLastComponent(double[] components)
    {
        return components[components.Length - 1];
    }
}