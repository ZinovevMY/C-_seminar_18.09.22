//Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

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

double[,] GenerateArray(int rows, int columns, int minRange, int maxRange)
{
    var array = new double[rows, columns];
    var random = new Random();
    var rnd = new Random();

    for (var i = 0; i < array.GetLength(0); i++)
    {
        for (var j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = Math.Round(random.NextDouble() * rnd.Next(minRange,maxRange),1);

        }
    }
    return array;
}

void PrintArray(double[,] array)
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
double[,] array = GenerateArray(rows, columns, -10, 11);
PrintArray(array);