//Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

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

void PrintResArray(double[] array)
{
    for (int j = 0; j < array.Length; j++)
    {
        System.Console.WriteLine($"Среднее арифметическое значений в {j}-м столбце равно {array[j]}.");
    }
    System.Console.WriteLine();
}


double[] CalculateAverage(int[,] arr)
{
    double[] average = new double[arr.GetLength(1)];
    double summ = 0;
    for (int i = 0; i < arr.GetLength(1); i++)
    {
        summ = 0;
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            summ += arr[j,i];
        }
        average[i] = summ/arr.GetLength(0);
    }
    return average;
}

int rowCount = Prompt("Введите кол-во строк массива: ");
int colCount = Prompt("Введите кол-во колонок массива: ");

int[,] myArray = GenerateArray(rowCount,colCount,1,25);
double[] resultArray = CalculateAverage(myArray);
PrintArray(myArray);
PrintResArray(resultArray);
