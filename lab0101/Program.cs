using System;

class Employee
{
    public string LastName { get; set; }
    public string Initials { get; set; }
    public int BirthYear { get; set; }
    public decimal Salary { get; set; }

    public Employee()
    {
    }

    public Employee(string lastName, string initials, int birthYear, decimal salary)
    {
        LastName = lastName;
        Initials = initials;
        BirthYear = birthYear;
        Salary = salary;
    }

    public Employee(Employee employee)
    {
        LastName = employee.LastName;
        Initials = employee.Initials;
        BirthYear = employee.BirthYear;
        Salary = employee.Salary;
    }

    ~Employee()
    {
        Console.WriteLine($"Співробітника {LastName} було видалено.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee ivanov = new Employee()
        {
            LastName = "Іванов",
            Initials = "І.І.",
            BirthYear = 1975,
            Salary = 517.50m
        };

        Employee petrenko = new Employee("Петренко", "П.П.", 1956, 219.10m);

        Employee panikovsky = new Employee(ivanov);
        panikovsky.LastName = "Паніковський";
        panikovsky.Initials = "М.С.";
        panikovsky.BirthYear = 1967;
        panikovsky.Salary = 300.00m;

        Console.WriteLine("╔═════════════╦═════════╦══════════════╦════════╗");
        Console.WriteLine("║   Прізвище  ║ Ініціали║Рік народження║ Оклад  ║");
        Console.WriteLine("╠═════════════╬═════════╬══════════════╬════════╣");
        Console.WriteLine($"║ {ivanov.LastName,-12}║{ivanov.Initials,-9}║ {ivanov.BirthYear,-13}║ {ivanov.Salary,7}║");
        Console.WriteLine($"║ {petrenko.LastName,-12}║{petrenko.Initials,-9}║ {petrenko.BirthYear,-13}║ {petrenko.Salary,7}║");
        Console.WriteLine($"║ {panikovsky.LastName,-12}║{panikovsky.Initials,-9}║ {panikovsky.BirthYear,-13}║ {panikovsky.Salary,7}║");
        Console.WriteLine("╚═════════════╩═════════╩══════════════╩════════╝");
    }
}

