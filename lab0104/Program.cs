using System;

class Element
{
    private int value;

    public Element(int value)
    {
        this.value = value;
    }

    public int GetValue()
    {
        return value;
    }

    public void SetValue(int value)
    {
        this.value = value;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Element other = (Element)obj;
        return value == other.value;
    }

    public override int GetHashCode()
    {
        return value.GetHashCode();
    }

    public override string ToString()
    {
        return value.ToString();
    }
}

class OneDimensionalArray
{
    private Element[] array;

    public OneDimensionalArray(int size)
    {
        array = new Element[size];
    }

    public void SetElement(int index, int value)
    {
        if (index >= 0 && index < array.Length)
        {
            array[index] = new Element(value);
        }
    }

    public int GetElement(int index)
    {
        if (index >= 0 && index < array.Length)
        {
            return array[index].GetValue();
        }

        return 0;
    }

    public void Add(OneDimensionalArray otherArray)
    {
        int minLength = Math.Min(array.Length, otherArray.array.Length);

        for (int i = 0; i < minLength; i++)
        {
            array[i].SetValue(array[i].GetValue() + otherArray.array[i].GetValue());
        }
    }

    public void Subtract(OneDimensionalArray otherArray)
    {
        int minLength = Math.Min(array.Length, otherArray.array.Length);

        for (int i = 0; i < minLength; i++)
        {
            array[i].SetValue(array[i].GetValue() - otherArray.array[i].GetValue());
        }
    }

    public void Multiply(OneDimensionalArray otherArray)
    {
        int minLength = Math.Min(array.Length, otherArray.array.Length);

        for (int i = 0; i < minLength; i++)
        {
            array[i].SetValue(array[i].GetValue() * otherArray.array[i].GetValue());
        }
    }

    public override string ToString()
    {
        string result = "";

        for (int i = 0; i < array.Length; i++)
        {
            result += array[i].ToString() + " ";
        }

        return result.Trim();
    }
}
class Program
{
    static void Main(string[] args)
    {
        OneDimensionalArray array1 = new OneDimensionalArray(5);
        array1.SetElement(0, 1);
        array1.SetElement(1, 2);
        array1.SetElement(2, 3);
        array1.SetElement(3, 4);
        array1.SetElement(4, 5);

        OneDimensionalArray array2 = new OneDimensionalArray(5);
        array2.SetElement(0, 2);
        array2.SetElement(1, 4);
        array2.SetElement(2, 6);
        array2.SetElement(3, 8);
        array2.SetElement(4, 10);

        Console.WriteLine("Array 1: " + array1.ToString());
        Console.WriteLine("Array 2: " + array2.ToString());

        array1.Add(array2);
        Console.WriteLine("Array 1 + Array 2: " + array1.ToString());

        array1.Subtract(array2);
        Console.WriteLine("Array 1 - Array 2: " + array1.ToString());

        array1.Multiply(array2);
        Console.WriteLine("Array 1 * Array 2: " + array1.ToString());

        Console.ReadLine();
    }
}
