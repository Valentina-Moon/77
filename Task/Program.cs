//Случайное заполнение массива вещественными числами ( задача № 1)
double[,] FillArrayByRandom(double[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
        for (int j = 0; j < matr.GetLength(1); j++)
            matr[i, j] = new Random().NextDouble() * 100;
    return matr;
}
//Показать двумерный массив размером m×n заполненный вещественными числами. ( задача № 1)
void PrintDoubleArray(double[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
            Console.Write($"{matr[i, j]}\t");
        Console.WriteLine();
    }
}
//Показать двумерный массив размером m×n заполненный целыми числами.
void PrintIntArray(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
            Console.Write($"{matr[i, j]}\t");
        Console.WriteLine();
    }
}
//Задать двумерный массив следующим правилом: Aₘₙ = m+n ( задача № 2)
int[,] FillArray(int[,] matr)
{
    for (int m = 0; m < matr.GetLength(0); m++)
        for (int n = 0; n < matr.GetLength(1); n++)
            matr[m, n] = m + n;
    return matr;
}
//В двумерном массиве показать позиции числа, заданного пользователем или указать, что такого элемента нет ( задача № 4)
int[] FindIndex(int[,] matr, int number)
{
    for (int i = 0; i < matr.GetLength(0); i++)
        for (int j = 0; j < matr.GetLength(1); j++)
            if (matr[i, j] == number)
                return new int[2] { i, j }; 
    return new int[2] { -1, -1 };
}
//В двумерном массиве заменить элементы, у которых оба индекса чётные на их квадраты ( задача № 3)
int[,] EvenIndexesToSqr(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
        for (int j = 0; j < matr.GetLength(1); j++)
            if (i % 2 == 0 && j % 2 == 0) 
                matr[i, j] *= matr[i, j];
    return matr;
}
//В матрице чисел найти сумму элементов главной диагонали  ( задача № 5)
int SumDiagonal(int[,] matr)
{
    int sum = 0;
    for (int i = 0; i < matr.GetLength(0); i++)
        for (int j = 0; j < matr.GetLength(1); j++)
            if (i == j) 
                sum += matr[i, j];
    return sum;
}
//Дан целочисленный массив. Найти среднее арифметическое каждого из столбцов. ( задача № 6)
double[] AvereageOfColumns(int[,] matr)
{
    double[] result = new double[matr.GetLength(1)];
    for (int j = 0; j < matr.GetLength(1); j++)
    {
        for (int i = 0; i < matr.GetLength(0); i++)
            result[j] += matr[i, j];
        result[j] /= matr.GetLength(0);
    }
    return result;
}
//Написать программу, которая обменивает элементы первой строки и последней строки  ( задача № 7)
int[,] ChangeFirstAndLast(int[,] matr)
{
    
    int temp = 0;
    for (int i = 0; i < matr.GetLength(1); i++)
    {
        temp = matr[0, i];
        matr[0, i] = matr[matr.GetLength(0) - 1, i];
        matr[matr.GetLength(0) - 1, i] = temp;
    }
    return matr;
}
//В прямоугольной матрице найти строку с наименьшей суммой элементов. ( задача № 8)
int MinStroke(int[,] matr)
{
    int minSum = 0;
    int minStroke = 0;
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < matr.GetLength(1); j++)
            sum += matr[i, j];

        if (sum < minSum||i==0)
        {
            minSum = sum;
            minStroke = i;
        }
    }
    return minStroke;
}

Console.WriteLine("Количество строк: ");
int m = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Количество столбцов: ");
int n = int.Parse(Console.ReadLine() ?? "0");


int[,] intMatrix = new int[m, n];
double[,] doubleMatrix = new double[m, n];

intMatrix = FillArray(intMatrix);
doubleMatrix = FillArrayByRandom(doubleMatrix);
PrintDoubleArray(doubleMatrix);
PrintIntArray(intMatrix);
var index = FindIndex(intMatrix, 7);
Console.WriteLine($"индекс числа 2 {index[0]},{index[1]}");

PrintIntArray(EvenIndexesToSqr(intMatrix));

Console.WriteLine("сумма главной диагонали"+SumDiagonal(intMatrix).ToString());
var avereageArray = AvereageOfColumns(intMatrix);
foreach(var avereage in avereageArray)
    Console.Write(avereage+ "\t");
Console.WriteLine();
PrintIntArray(ChangeFirstAndLast(intMatrix));
Console.WriteLine("минималная строка "+MinStroke(intMatrix).ToString());