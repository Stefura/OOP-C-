using System;

class ListNode
{
    public char Value { get; set; }
    public ListNode Next { get; set; }

    public ListNode(char value)
    {
        Value = value;
        Next = null;
    }
}

class LinkedList
{
    private ListNode head;
    private ListNode tail;

    public char this[int index]
    {
        get
        {
            ListNode current = head;
            int count = 0;

            while (current != null)
            {
                if (count == index)
                    return current.Value;

                current = current.Next;
                count++;
            }

            throw new IndexOutOfRangeException("Index is out of range.");
        }
    }

    public static LinkedList operator +(LinkedList list1, LinkedList list2)
    {
        LinkedList newList = new LinkedList();

        ListNode current = list1.head;
        while (current != null)
        {
            newList.Add(current.Value);
            current = current.Next;
        }

        current = list2.head;
        while (current != null)
        {
            newList.Add(current.Value);
            current = current.Next;
        }

        return newList;
    }

    public static bool operator ==(LinkedList list1, LinkedList list2)
    {
        if (list1.Length() != list2.Length())
            return false;

        ListNode current1 = list1.head;
        ListNode current2 = list2.head;

        while (current1 != null && current2 != null)
        {
            if (current1.Value != current2.Value)
                return false;

            current1 = current1.Next;
            current2 = current2.Next;
        }

        return true;
    }

    public static bool operator !=(LinkedList list1, LinkedList list2)
    {
        return !(list1 == list2);
    }

    public void Add(char value)
    {
        ListNode newNode = new ListNode(value);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
    }

    public int Length()
    {
        int count = 0;
        ListNode current = head;

        while (current != null)
        {
            count++;
            current = current.Next;
        }

        return count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList list1 = new LinkedList();
        list1.Add('a');
        list1.Add('b');
        list1.Add('c');

        LinkedList list2 = new LinkedList();
        list2.Add('d');
        list2.Add('e');
        list2.Add('f');

        LinkedList combinedList = list1 + list2;
        Console.WriteLine("Об'єднаний список: " + string.Join(", ", combinedList));

        bool notEqual = list1 != list2;
        Console.WriteLine("Перевірка на нерівність: " + notEqual);

        char element = list1[1];
        Console.WriteLine($"Елемент в заданій позиції: {element}");
    }
}




