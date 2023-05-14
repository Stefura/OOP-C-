using System;
using System.Collections.Generic;
using System.Linq;

class CollectionType<T>
{
    public LinkedList<T> Collection { get; set; }

    public CollectionType()
    {
        Collection = new LinkedList<T>();
    }
}

class Program
{
    static void Main(string[] args)
    {
        CollectionType<int>[] collectionArray = new CollectionType<int>[]
        {
            new CollectionType<int> { Collection = new LinkedList<int>(new[] { 1, 2, 3 }) },
            new CollectionType<int> { Collection = new LinkedList<int>(new[] { 4, 5, 6 }) },
            new CollectionType<int> { Collection = new LinkedList<int>(new[] { 7, 8, 9 }) }
        };

        int targetValue = 2;
        int count = collectionArray.Count(item => item.Collection.Contains(targetValue));
        Console.WriteLine($"Кількість колекцій, що містять значення {targetValue}: {count}");

        var maxCollection = collectionArray.OrderByDescending(item => item.Collection.Count).First();
        Console.WriteLine($"Максимальна колекція: {string.Join(", ", maxCollection.Collection)}");

        var minCollection = collectionArray.OrderBy(item => item.Collection.Count).First();
        Console.WriteLine($"Мінімальна колекція: {string.Join(", ", minCollection.Collection)}");

        Console.ReadLine();
    }
}
