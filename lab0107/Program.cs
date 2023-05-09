using System;
using System.Collections.Generic;
using System.Xml.Linq;


class Airport
{
    public string Name { get; set; }

    public Airport(string name)
    {
        Name = name;
    }
}

abstract class Aircraft
{
    public string Name { get; set; }
    public int MaxPassengers { get; set; }

    public abstract void TakeOff();
}

class Airplane : Aircraft
{
    public Airplane(string name, int maxPassengers)
    {
        Name = name;
        MaxPassengers = maxPassengers;
    }

    public override void TakeOff()
    {
        Console.WriteLine("Літак злітає...");
    }

    public virtual void AddPassenger(Passenger passenger)
    {
        Console.WriteLine("Додавання пасажира...");
        if (passenger != null)
        {
            Console.WriteLine($"Пасажир {passenger.FullName} доданий.");
        }
    }
}

class AirplaneWithRunway : Airplane
{
    private int runwayLength;
    private List<Passenger> passengers;

    public int RunwayLength
    {
        get { return runwayLength; }
        set
        {
            if (value <= 0)
            {
                throw new SmugaRozgonuException(value);
            }
            runwayLength = value;
        }
    }

    public AirplaneWithRunway(string name, int maxPassengers, int runwayLength) : base(name, maxPassengers)
    {
        RunwayLength = runwayLength;
        passengers = new List<Passenger>();
    }

    public override void TakeOff()
    {
        try
        {
            if (RunwayLength < 1000)
            {
                throw new Exception("Недостатня довжина смуги розгону");
            }
            Console.WriteLine($"Літак {Name} злітає...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    public override void AddPassenger(Passenger passenger)
    {
        try
        {
            if (passengers.Count >= MaxPassengers)
            {
                throw new KilkistException("Досягнуто максимальну кількість пасажирів.");
            }
            passengers.Add(passenger);
            Console.WriteLine($"Пасажир {passenger.FullName} додано.");
        }
        catch (KilkistException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}

class Helicopter : Aircraft
{
    public Helicopter(string name, int maxPassengers)
    {
        Name = name;
        MaxPassengers = maxPassengers;
    }

    public override void TakeOff()
    {
        try
        {
            Console.WriteLine($"Гелікоптер {Name} злітає...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}

class Passenger
{
    public string FullName { get; set; }
    public int SeatNumber { get; set; }

    public Passenger(string fullName, int seatNumber)
    {
        FullName = fullName;
        SeatNumber = seatNumber;
    }
}

class KilkistException : Exception
{
    public KilkistException(string message) : base(message) { }
}

class SmugaRozgonuException : Exception
{
    public int SmugaRozgonu { get; }

    public SmugaRozgonuException(int smugaRozgonu)
    {
        SmugaRozgonu = smugaRozgonu;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Aircraft airplane = new AirplaneWithRunway("Boeing 747", 300, 800);
            airplane.TakeOff();

            Aircraft helicopter = new Helicopter("Robinson R44", 4);
            helicopter.TakeOff();

            AirplaneWithRunway airplane2 = new AirplaneWithRunway("Boeing 777", 500, 2000);
            airplane2.TakeOff();

            airplane2.AddPassenger(new Passenger("Джон Сміт", 1));
            airplane2.AddPassenger(new Passenger("Джейн Доу", 2));
            airplane2.AddPassenger(new Passenger("Боб Джонсон", 3));
            airplane2.AddPassenger(new Passenger("Еліс Браун", 4));
            airplane2.AddPassenger(new Passenger("Єва Вілсон", 5));
            airplane2.AddPassenger(new Passenger("Майкл Девіс", 6)); 
        }
        catch (KilkistException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        catch (SmugaRozgonuException ex)
        {
            Console.WriteLine($"Неможливо створити літак - вказана неправильна довжина смуги розгону: {ex.SmugaRozgonu}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}

