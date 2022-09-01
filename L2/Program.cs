/* Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку
с наименьшей суммой элементов. Программа считает сумму элементов в каждой строке и выдаёт номер
строки с наименьшей суммой элементов: 1 строка */

int[,] FillArray(int numLine, int numColumns, int maxRand = 20, int minRand = 0)         // Функция создания и заполнения двумерного массива случайными числами  
{
    int[,] matrix = new int[numLine, numColumns];
    for (int i = 0; i < matrix.GetLength(0); i++)   // Строка
    {
        for (int j = 0; j < matrix.GetLength(1); j++)     // Столбец
        {
            matrix[i, j] = new Random().Next(minRand, maxRand);      // [0; 20) по умолчанию 
        }
    }
    return matrix;
}

void PrintArray(int[,] matrix)              // Функция печати двумерного массива 
{
    for (int i = 0; i < matrix.GetLength(0); i++)   // Строка
    {
        for (int j = 0; j < matrix.GetLength(1); j++)   // Столбец
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int[] SumOfLine(int[,] matrix)      // Функция вычисляет сумму элементов построчно
{
    int[] sum = new int[matrix.GetLength(0)];     // Массив для хранения результатов
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sum[i] = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum[i] += matrix[i, j];
        }
    }
    return sum;
}

void ArrayPrint(int[] myArr)                            // Функция печати одномерного массива    
{
    for (int j = 0; j < myArr.Length; j++)
    {
        System.Console.Write($"{myArr[j]}\t");
    }
}

int MinIndex(int[] array)                              // Функция нахождения индекса минимального элемента
{
    int minNum = array[0];
    int index = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] < minNum)
        {
            minNum = array[i];
            index = i;
        }
    }
    return index;
}


int[,] matrix = FillArray(3, 3);
PrintArray(matrix);
System.Console.WriteLine();
int[] sum = SumOfLine(matrix);
ArrayPrint(sum);
System.Console.WriteLine();
System.Console.WriteLine($"Наименьшая сумма элементов в {MinIndex(sum)} строке");
System.Console.WriteLine($"Наименьшая сумма элементов для пользователя в {MinIndex(sum) + 1} строке");