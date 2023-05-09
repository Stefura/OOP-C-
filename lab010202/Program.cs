using System;

class Employee
{
    public string LastName { get; set; }
    public string Initials { get; set; }
    public int BirthYear { get; set; }
    public decimal Salary { get; set; }

    public static int Count { get; private set; }

    public Employee()
    {
        Count++;
    }

    public Employee(string lastName, string initials, int birthYear, decimal salary)
    {
        LastName = lastName;
        Initials = initials;
        BirthYear = birthYear;
        Salary = salary;
        Count++;
    }

    public Employee(Employee employee)
    {
        LastName = employee.LastName;
        Initials = employee.Initials;
        BirthYear = employee.BirthYear;
        Salary = employee.Salary;
        Count++;
    }

    ~Employee()
    {
        Count--;
        Console.WriteLine($"Співробітник {LastName} було видалено.");
    }

    public override string ToString()
    {
        return $"Прізвище: {LastName}\nІніціали: {Initials}\nРік народження: {BirthYear}\nОклад: {Salary}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee[] employees = new Employee[10];

        employees[0] = new Employee("Іванов", "І.І.", 1975, 517.50m);
        employees[1] = new Employee("Петренко", "П.П.", 1956, 219.10m);
        employees[2] = new Employee("Паніковський", "М.С.", 1967, 300.00m);

        Console.WriteLine("Всі Співробітники:");
        PrintEmployees(employees);

        decimal searchSalary = 300.00m;
        Employee[] filteredEmployees = FindEmployeesBySalary(employees, searchSalary);

        Console.WriteLine($"\nПрацівники із зарплатою менше ніж {searchSalary}:");
        PrintEmployees(filteredEmployees);

        int maxObjects = 15;
        int minObjects = 5;

        if (Employee.Count > maxObjects)
        {
            Console.WriteLine($"\nЗабагато об'єктів. Поточна кількість: {Employee.Count}. Максимально дозволено: {maxObjects}");
        }
        else if (Employee.Count < minObjects)
        {
            Console.WriteLine($"\nЗамало об'єктів. Поточна кількість: {Employee.Count}. Необхідний мінімум: {minObjects}");
        }
        else
        {
            Console.WriteLine($"\nКількість об'єктів у межах дозволеного діапазону. Поточна кількість: {Employee.Count}");
        }
    }

    static void PrintEmployees(Employee[] employees)
    {
        foreach (Employee employee in employees)
        {
            if (employee != null)
            {
                Console.WriteLine(employee.ToString());
                Console.WriteLine("-------------------------");
            }
        }
    }

    static Employee[] FindEmployeesBySalary(Employee[] employees, decimal salaryThreshold)
    {
        Employee[] filteredEmployees = new Employee[employees.Length];
        int count = 0;

        foreach (Employee employee in employees)
        {
            if (employee != null && employee.Salary < salaryThreshold)
            {
                filteredEmployees[count] = employee;
                count++;
            }
        }

        Array.Resize(ref filteredEmployees, count);
        return filteredEmployees;
    }
}

