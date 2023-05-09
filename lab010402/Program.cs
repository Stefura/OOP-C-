using System;

class TPair
{
    protected int value1;
    protected int value2;

    public TPair(int value1, int value2)
    {
        this.value1 = value1;
        this.value2 = value2;
    }

    public virtual void Increase()
    {
        value1++;
        value2++;
    }

    public virtual void Decrease()
    {
        value1--;
        value2--;
    }

    public override string ToString()
    {
        return $"({value1}, {value2})";
    }
}

class TTime : TPair
{
    public TTime(int hours, int minutes) : base(hours, minutes)
    {
    }

    public override void Increase()
    {
        value1 += 1;
        if (value1 >= 24)
        {
            value1 = 0;
        }
    }

    public override void Decrease()
    {
        value1 -= 1;
        if (value1 < 0)
        {
            value1 = 23;
        }
    }

    public int Hours
    {
        get { return value1; }
    }

    public int Minutes
    {
        get { return value2; }
    }
}

class TMoney : TPair
{
    public TMoney(int hryvnia, int kopiyka) : base(hryvnia, kopiyka)
    {
    }

    public override void Increase()
    {
        value1 += 1;
        if (value1 >= 100)
        {
            value1 = 0;
            value2 += 1;
        }
    }

    public override void Decrease()
    {
        value1 -= 1;
        if (value1 < 0)
        {
            value1 = 99;
            value2 -= 1;
        }
    }

    public int Hryvnia
    {
        get { return value1; }
    }

    public int Kopiyka
    {
        get { return value2; }
    }

    public override string ToString()
    {
        return $"{value1} грн {value2:00} коп";
    }
}

class Program
{
    static void Main(string[] args)
    {
        int n = 5;

        Random random = new Random();
        TTime[] times = new TTime[n];
        TMoney[] moneys = new TMoney[n];

        for (int i = 0; i < n; i++)
        {
            int hours = random.Next(24);
            int minutes = random.Next(60);
            times[i] = new TTime(hours, minutes);

            int hryvnia = random.Next(1000);
            int kopiyka = random.Next(100);
            moneys[i] = new TMoney(hryvnia, kopiyka);
        }

        for (int i = 0; i < n; i++)
        {
            int totalMinutes = times[i].Hours * 60 + times[i].Minutes;
            decimal costPerMinute = (decimal)moneys[i].Hryvnia + (decimal)moneys[i].Kopiyka / 100;
            decimal totalCost = totalMinutes * costPerMinute;

            Console.WriteLine($"Робота {i + 1}:");
            Console.WriteLine($"Тривалість: {times[i].Hours} год {times[i].Minutes} хв");
            Console.WriteLine($"Вартість за хвилину: {moneys[i]}");
            Console.WriteLine($"Загальна вартість: {totalCost} грн");
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}
