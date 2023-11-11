using System;

class Programm
{
    public static char[] charArayOfOperations = { '+', '-', '*', '/' };
    public static string[] stringArrayOfOperations = { "+", "-", "*", "/" };
    public static char[] charArrayOfNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    static void Main()
    {
        string userInput = Console.ReadLine();

        List<string> nums = GetListOfNumbers(userInput);
        List<string> operations = GetListOfOperations(userInput);

        OutputList(nums);
        OutputList(operations);
    }

    static void OutputList(List<string> list)
    {
        foreach (string character in list)
        {
            Console.Write(character + "  ");
        }
        Console.WriteLine();
    }

    public static List<string> GetListOfNumbers(string userInput)
    {
        string inputWithoutSpace = userInput.Replace(" ", "");

        string strokeOfNums = ReplaceChar(inputWithoutSpace, charArayOfOperations, ' ');
        string[] nums = strokeOfNums.Trim().Split(' ');

        List<string> numbers = new List<string>();

        int i = 0;
        while (i < nums.Length)
        {
            numbers.Add(nums[i]);
            i++;
        }
        return numbers;
    }

    public static List<string> GetListOfOperations(string userInput)
    {
        List<string> operations = new List<string>();

        string strokeOfOperations = ReplaceChar(userInput, charArrayOfNumbers, ' ');
        string[] arrayOfOperations = strokeOfOperations.Split(" ");

        int i = 0;
        int k = 0;
        while (i < arrayOfOperations.Length)
        {
            if (k < stringArrayOfOperations.Length && arrayOfOperations[i] == stringArrayOfOperations[k])
            {
                operations.Add(arrayOfOperations[i]);
                i++;
                k = 0;
            }
            else if (k != stringArrayOfOperations.Length && arrayOfOperations[i] != stringArrayOfOperations[k])
            {
                k++;
            }
            else if (k == stringArrayOfOperations.Length)
            {
                i++;
                k = 0;
            }
        }
        return operations;
    }

    public static string ReplaceChar(string userInput, char[] objects, char changingChar)
    {
        int i = 0;
        while (i < objects.Length)
        {
            char replacementChar = objects[i];
            userInput = userInput.Replace(replacementChar, changingChar);
            i++;
        }
        return userInput;
    }
}
