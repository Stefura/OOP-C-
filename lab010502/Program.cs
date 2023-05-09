using System;

interface Printable
{
    void Print();
}

class Book : Printable
{
    private string title;

    public Book(string title)
    {
        this.title = title;
    }

    public void Print()
    {
        Console.WriteLine("Книга: " + title);
    }
}

class Magazine : Printable
{
    private string title;

    public Magazine(string title)
    {
        this.title = title;
    }

    public void Print()
    {
        Console.WriteLine("Журнал: " + title);
    }

    public static void PrintMagazines(Printable[] printables)
    {
        foreach (Printable printable in printables)
        {
            if (printable is Magazine)
            {
                printable.Print();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Printable[] printables = new Printable[]
        {
            new Book("Гаррі Поттер"),
            new Magazine("Viva!"),
            new Book("Найбагатший чоловік у Вавилоні"),
            new Magazine("Здоров'я")
        };

        foreach (Printable printable in printables)
        {
            printable.Print();
        }

        Console.WriteLine("Друк журналів:");
        Magazine.PrintMagazines(printables);

        Console.ReadLine();
    }
}
