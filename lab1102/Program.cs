using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть дату у форматі 'дд.мм.рррр':");
        string inputDate = Console.ReadLine();

        DateTime currentDate = DateTime.Now;
        DateTime targetDate = DateTime.ParseExact(inputDate, "dd.MM.yyyy", null);

        if (targetDate < currentDate)
        {
            Console.WriteLine("Ця дата вже минула.");
        }
        else
        {
            TimeSpan remainingDays = targetDate - currentDate;
            int days = remainingDays.Days;

            Console.WriteLine($"До вказаної дати залишилось {days} днів.");
        }
    }
}
