using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть початковий рядок:");
        string input = Console.ReadLine();

        Console.WriteLine("Введіть позицію, з якої почати заміну:");
        int position = int.Parse(Console.ReadLine());

        string result = ReplaceCharacters(input, position);
        Console.WriteLine("Результат:");
        Console.WriteLine(result);
    }

    static string ReplaceCharacters(string input, int position)
    {
        char[] charArray = input.ToCharArray();

        for (int i = position; i < charArray.Length; i++)
        {
            if (charArray[i] == '0')
                charArray[i] = '1';
            else if (charArray[i] == '1')
                charArray[i] = '0';
        }

        return new string(charArray);
    }
}
