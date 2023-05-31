using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть рядок з трьома різними датами, розділеними комою:");
        string input = Console.ReadLine();

        string[] dates = input.Split(',');

        int minYear = GetYear(dates[0]);
        for (int i = 1; i < dates.Length; i++)
        {
            int year = GetYear(dates[i]);
            if (year < minYear)
            {
                minYear = year;
            }
        }
        Console.WriteLine($"Рік з найменшим номером: {minYear}");

        Console.WriteLine("Весняні дати:");
        foreach (var date in dates)
        {
            if (IsSpringDate(date))
            {
                Console.WriteLine(date);
            }
        }

        DateTime latestDate = DateTime.MinValue;
        foreach (var date in dates)
        {
            DateTime parsedDate = DateTime.Parse(date);
            if (parsedDate > latestDate)
            {
                latestDate = parsedDate;
            }
        }
        Console.WriteLine($"Сама пізніша дата: {latestDate.ToShortDateString()}");
    }

    static int GetYear(string date)
    {
        string[] parts = date.Split();
        return int.Parse(parts[2]);
    }

    static bool IsSpringDate(string date)
    {
        string[] parts = date.Split();
        int month = int.Parse(parts[1]);
        return month >= 3 && month <= 5;
    }
}
