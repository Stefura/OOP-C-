using System;

class Employee
{
    protected string surname;
    protected double salary;
    protected int hireYear;

    public Employee(string surname, double salary, int hireYear)
    {
        this.surname = surname;
        this.salary = salary;
        this.hireYear = hireYear;
    }

    public int CalculateExperience()
    {
        int currentYear = DateTime.Now.Year;
        int experience = currentYear - hireYear;
        return experience;
    }

    public int CalculateDaysAfterHireYear()
    {
        int currentYear = DateTime.Now.Year;
        int daysAfterHireYear = (currentYear - hireYear) * 365;
        return daysAfterHireYear;
    }

    public string GetInfoString()
    {
        string info = $"Прізвище: {surname}\nЗарплата: {salary}\nРік найму: {hireYear}";
        return info;
    }
}

class CompanyEmployee : Employee
{
    private int birthYear;

    public CompanyEmployee(string surname, double salary, int hireYear, int birthYear)
        : base(surname, salary, hireYear)
    {
        this.birthYear = birthYear;
    }

    public int CalculateYearsToRetirement()
    {
        int retirementAge = 60;
        int currentYear = DateTime.Now.Year;
        int yearsToRetirement = retirementAge - (currentYear - birthYear);
        return yearsToRetirement;
    }

    public string GetInfoString()
    {
        string info = base.GetInfoString() + $"\nРік народження: {birthYear}";
        return info;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee("Петрушен", 2000, 2010);
        Console.WriteLine("Інформація про співробітника:");
        Console.WriteLine(employee.GetInfoString());
        Console.WriteLine("Досвід: " + employee.CalculateExperience() + " років");
        Console.WriteLine("Днів після найму: " + employee.CalculateDaysAfterHireYear() + " днів");

        Console.WriteLine();

        CompanyEmployee companyEmployee = new CompanyEmployee("Цаль", 3000, 2015, 1985);
        Console.WriteLine("Інформація про співробітника компанії:");
        Console.WriteLine(companyEmployee.GetInfoString());
        Console.WriteLine("Досвід: " + companyEmployee.CalculateExperience() + " років");
        Console.WriteLine("Днів після найму: " + companyEmployee.CalculateDaysAfterHireYear() + " днів");
        Console.WriteLine("Роки до пенсії: " + companyEmployee.CalculateYearsToRetirement() + " років");
    }
}
