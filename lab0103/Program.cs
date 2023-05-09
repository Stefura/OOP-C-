using System;

class Person
{
    protected int age;

    public void Greet()
    {
        Console.WriteLine("Привіт!");
    }

    public void SetAge(int age)
    {
        this.age = age;
    }
}

class Student : Person
{
    public void Study()
    {
        Console.WriteLine("я навчаюся");
    }

    public void ShowAge()
    {
        Console.WriteLine($"Мій вік: {age} років");
    }
}

class Professor : Person
{
    public void Explain()
    {
        Console.WriteLine("Я пояснюю");
    }
}

class StudentProfessorTest
{
    static void Main(string[] args)
    {
        Student student = new Student();
        student.SetAge(20);
        Console.WriteLine("Привіт!");
        student.ShowAge();
        student.Study();
        Console.WriteLine();

        Professor professor = new Professor();
        professor.SetAge(40);
        Console.WriteLine("Привіт!");
        professor.Explain();
        Console.WriteLine();
    }
}