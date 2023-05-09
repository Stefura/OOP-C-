using System;
using System.Linq;

interface IManClothing
{
    void DressMan();
}

interface IWomanClothing
{
    void DressWoman();
}

abstract class Clothing
{
    protected string size;
    protected decimal cost;
    protected string color;

    public Clothing(string size, decimal cost, string color)
    {
        this.size = size;
        this.cost = cost;
        this.color = color;
    }
}

class TShirt : Clothing, IManClothing, IWomanClothing
{
    public TShirt(string size, decimal cost, string color) : base(size, cost, color) { }

    public void DressMan()
    {
        Console.WriteLine($"Одягання чоловіка в футболку [Розмір: {size}, Вартість: {cost}, Колір: {color}]");
    }

    public void DressWoman()
    {
        Console.WriteLine($"Одягання жінки в футболку [Розмір: {size}, Вартість: {cost}, Колір: {color}]");
    }
}

class Pants : Clothing, IManClothing, IWomanClothing
{
    public Pants(string size, decimal cost, string color) : base(size, cost, color) { }

    public void DressMan()
    {
        Console.WriteLine($"Одягання чоловіка в брюки [Розмір: {size}, Вартість: {cost}, Колір: {color}]");
    }

    public void DressWoman()
    {
        Console.WriteLine($"Одягання жінки в брюки [Розмір: {size}, Вартість: {cost}, Колір: {color}]");
    }
}

class Skirt : Clothing, IWomanClothing
{
    public Skirt(string size, decimal cost, string color) : base(size, cost, color) { }

    public void DressWoman()
    {
        Console.WriteLine($"Одягання жінки в Спідницю [Розмір: {size}, Вартість: {cost}, Колір: {color}]");
    }
}

class Tie : Clothing, IManClothing
{
    public Tie(string size, decimal cost, string color) : base(size, cost, color) { }

    public void DressMan()
    {
        Console.WriteLine($"Одягання чоловіка в Краватку [Розмір: {size}, Вартість: {cost}, Колір: {color}]");
    }
}

class Atelier
{
    public void DressWoman(IWomanClothing[] clothingItems)
    {
        Console.WriteLine("Одягання жінки:");
        foreach (IWomanClothing clothing in clothingItems)
        {
            clothing.DressWoman();
        }
    }

    public void DressMan(IManClothing[] clothingItems)
    {
        Console.WriteLine("Одягання чоловіка:");
        foreach (IManClothing clothing in clothingItems)
        {
            clothing.DressMan();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Clothing[] clothingItems = new Clothing[]
        {
            new TShirt("M", 20, "Червоний"),
            new Pants("L", 30, "Синій"),
            new Skirt("S", 25, "чорний"),
            new Tie("L", 15, "Жовтий")
        };

        Atelier atelier = new Atelier();
        atelier.DressWoman(clothingItems.OfType<IWomanClothing>().ToArray());
        atelier.DressMan(clothingItems.OfType<IManClothing>().ToArray());

        Console.ReadLine();
    }
}
