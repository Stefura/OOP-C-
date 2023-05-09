using System;

class User
{
    protected string name;
    protected int age;

    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }

    public void setAge(int age)
    {
        this.age = age;
    }

    public int getAge()
    {
        return age;
    }
}

class Worker : User
{
    private double salary;

    public void setSalary(double salary)
    {
        this.salary = salary;
    }

    public double getSalary()
    {
        return salary;
    }
}

class Student : User
{
    private double scholarship;
    private int course;

    public void setScholarship(double scholarship)
    {
        this.scholarship = scholarship;
    }

    public double getScholarship()
    {
        return scholarship;
    }

    public void setCourse(int course)
    {
        this.course = course;
    }

    public int getCourse()
    {
        return course;
    }
}

class Driver : Worker
{
    private int drivingExperience;
    private string drivingCategory;

    public void setDrivingExperience(int drivingExperience)
    {
        this.drivingExperience = drivingExperience;
    }

    public int getDrivingExperience()
    {
        return drivingExperience;
    }

    public void setDrivingCategory(string drivingCategory)
    {
        this.drivingCategory = drivingCategory;
    }

    public string getDrivingCategory()
    {
        return drivingCategory;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Worker ivan = new Worker();
        ivan.setName("Іван");
        ivan.setAge(25);
        ivan.setSalary(1000);

        Worker vasya = new Worker();
        vasya.setName("Вася");
        vasya.setAge(26);
        vasya.setSalary(2000);

        double totalSalary = ivan.getSalary() + vasya.getSalary();
        Console.WriteLine("Сума зарплат Івана і Васі: " + totalSalary);

        Student student = new Student();
        student.setName("Олексій");
        student.setAge(20);
        student.setScholarship(500);
        student.setCourse(3);

        Driver driver = new Driver();
        driver.setName("Михайло");
        driver.setAge(30);
        driver.setSalary(1500);
        driver.setDrivingExperience(5);
        driver.setDrivingCategory("B");

        Console.WriteLine("\nІнформація про студента:");
        Console.WriteLine("Ім'я: " + student.getName());
        Console.WriteLine("Вік: " + student.getAge());
        Console.WriteLine("Стипендія: " + student.getScholarship());
        Console.WriteLine("Курс: " + student.getCourse());

        Console.WriteLine("\nІнформація про водія:");
        Console.WriteLine("Ім'я: " + driver.getName());
        Console.WriteLine("Вік: " + driver.getAge());
        Console.WriteLine("Зарплата: " + driver.getSalary());
        Console.WriteLine("Водійський стаж: " + driver.getDrivingExperience());
        Console.WriteLine("Категорія водіння: " + driver.getDrivingCategory());
    }
}
