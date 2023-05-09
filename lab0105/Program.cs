using System;

interface IShape
{
    void DisplayType();
    void DisplayArea();
    double Size { get; }
}

interface IColoredShape : IShape
{
    string Color { get; }
    void DisplayColor();
}

class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public void DisplayType()
    {
        Console.WriteLine("Фігура: Круг");
    }

    public void DisplayArea()
    {
        double area = Math.PI * radius * radius;
        Console.WriteLine($"Площа: {area}");
    }

    public double Size
    {
        get { return radius; }
    }
}

class ColoredCircle : IColoredShape
{
    private double radius;
    private string color;

    public ColoredCircle(double radius, string color)
    {
        this.radius = radius;
        this.color = color;
    }

    public void DisplayType()
    {
        Console.WriteLine("Фігура: Кольорове коло");
    }

    public void DisplayArea()
    {
        double area = Math.PI * radius * radius;
        Console.WriteLine($"Площа: {area}");
    }

    public void DisplayColor()
    {
        Console.WriteLine($"Колір: {color}");
    }

    public double Size
    {
        get { return radius; }
    }

    public string Color
    {
        get { return color; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IShape[] shapes = new IShape[]
        {
            new Circle(5),
            new Circle(7),
            new Circle(3),
            new ColoredCircle(4, "Червоний"),
            new ColoredCircle(6, "Синій"),
            new ColoredCircle(2, "Зелений")
        };

        foreach (IShape shape in shapes)
        {
            shape.DisplayType();
            shape.DisplayArea();

            if (shape is IColoredShape coloredShape)
            {
                coloredShape.DisplayColor();
            }

            Console.WriteLine();
        }

        Console.ReadLine();
    }
}
