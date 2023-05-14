using System;

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
    public int RunwayLength { get; set; }

    public Airplane(string name, int maxPassengers, int runwayLength)
    {
        Name = name;
        MaxPassengers = maxPassengers;
        RunwayLength = runwayLength;
    }

    public override void TakeOff()
    {
        try
        {
            if (RunwayLength <= 0)
            {
                throw new SmugaRozgonuException(RunwayLength);
            }
            Console.WriteLine($"Літак {Name} злітає...");
        }
        catch (SmugaRozgonuException ex)
        {
            Console.WriteLine($"Неможливо створити літак - вказана неправильна довжина смуги розгону: {ex.RunwayLength}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    public void AddPassenger(Passenger passenger)
    {
        try
        {
            if (passenger == null)
            {
                throw new ArgumentNullException(nameof(passenger));
            }

            if (passenger.SeatNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(passenger.SeatNumber), "Номер посадкового місця повинен бути більше 0.");
            }

            if (passenger.SeatNumber > MaxPassengers)
            {
                throw new KilkistException("Досягнуто максимальну кількість пасажирів.");
            }

            Console.WriteLine($"Пасажир {passenger.FullName} доданий.");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
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
    public int RunwayLength { get; }

    public SmugaRozgonuException(int runwayLength)
    {
        RunwayLength = runwayLength;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Aircraft airplane = new Airplane("Boeing 747", 300, 800);
            airplane.TakeOff();

            Aircraft helicopter = new Helicopter("Robinson R44", 4);
            helicopter.TakeOff();

            Airplane airplane2 = new Airplane("Boeing 777", 500, 2000);
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
            Console.WriteLine($"Неможливо створити літак - вказана неправильна довжина смуги розгону: {ex.RunwayLength}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}

