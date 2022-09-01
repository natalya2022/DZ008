/* Задайте двумерный массив. Напишите программу, которая упорядочит по 
убыванию элементы каждой строки двумерного массива. */


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
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] BubbleSortLines(int[,] matrix)   // Функция выполняет пузырьковую сортировку строк по убыванию
{
    for (int i = 0; i < matrix.GetLength(0); i++)   // Строка
    {
        for (int k = 0; k < matrix.GetLength(1) - 1; k++)   // Количество проходов
        {
            bool flagSort = true;                           // Флаг готовой сортировки строки    
            for (int j = 0; j < matrix.GetLength(1) - 1 - k; j++)   // Передвижение внутри строки
            {
                if (matrix[i, j] < matrix[i, j + 1])
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, j + 1];
                    matrix[i, j + 1] = temp;
                    flagSort = false;
                }
            }
            if (flagSort) { break; }
        }
    }
    return matrix;
}


int[,] array = FillArray(3, 5);
PrintArray(array);
System.Console.WriteLine();
int[,] answer = BubbleSortLines(array);
PrintArray(answer);
