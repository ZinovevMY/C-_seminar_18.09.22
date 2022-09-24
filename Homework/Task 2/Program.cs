//Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание,
//что такого элемента нет.

int Prompt(string messege)
{
    Console.Write(messege);
    string strValue = Console.ReadLine() ?? "0";
    bool isNumber = int.TryParse(strValue, out int value);
    if (isNumber)
    {
        return value;
    }
    throw new Exception("Данное значение не возможно преобразовать в число");
}

int[,] GenerateArray(int rows, int columns, int minRange, int maxRange)
{
    var array = new int[rows, columns];
    var random = new Random();

    for (var i = 0; i < array.GetLength(0); i++)
    {
        for (var j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(minRange,maxRange);
        }
    }
    return array;
}

bool IsOutOfRange(int[,] arr, int rowNumber, int columnNumber)
{
    return (rowNumber > arr.GetLength(0) || columnNumber > arr.GetLength(1));
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]}\t");
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

int rows = Prompt("Введите кол-во строк в массиве: ");
int columns = Prompt("Введите кол-во столбцов в массиве: ");
int[,] array = GenerateArray(rows, columns, -5, 6);
int rowNumber = Prompt("Введите номер строки в массиве: ");
int colNumber = Prompt("Введите номер столбца в массиве: ");

if (!IsOutOfRange(array,rowNumber,colNumber))
{
    PrintArray(array);
    System.Console.WriteLine($"В {colNumber} столбце {rowNumber} строки находится значение {array[rowNumber-1,colNumber-1]}");
}
else
{
    System.Console.WriteLine("Элемента с такими координатами в массиве нет!");
}
