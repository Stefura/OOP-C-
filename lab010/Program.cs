using System;
using System.Collections.Generic;

class CharSet
{
    private HashSet<char> set;

    public CharSet()
    {
        set = new HashSet<char>();
    }

    public CharSet(params char[] elements)
    {
        set = new HashSet<char>(elements);
    }

    public static CharSet operator +(CharSet set, char element)
    {
        set.set.Add(element);
        return set;
    }

    public static CharSet operator *(CharSet set1, CharSet set2)
    {
        CharSet resultSet = new CharSet();
        foreach (char element in set1.set)
        {
            if (set2.set.Contains(element))
            {
                resultSet.set.Add(element);
            }
        }
        return resultSet;
    }

    public static int operator !(CharSet set)
    {
        return set.set.Count;
    }

    public override string ToString()
    {
        return string.Join(", ", set);
    }
}

class Program
{
    static void Main(string[] args)
    {
        CharSet set1 = new CharSet('a', 'b', 'c');
        CharSet set2 = new CharSet('b', 'c', 'd');
        CharSet set3 = new CharSet('c', 'd', 'e');

        CharSet resultSet1 = set1 + 'd';
        Console.WriteLine("додати елемент в множину: " + resultSet1);

        CharSet resultSet2 = set1 * set2;
        Console.WriteLine("перетин множин: " + resultSet2);

        int powerSet3 = !set3;
        Console.WriteLine("потужність множини: " + powerSet3);
    }
}
