/* Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц. */

int Prompt(string message)
{
    System.Console.Write(message);                    // Вывести сообщение
    int result = Convert.ToInt32(Console.ReadLine()); // Считывает значение
    return result;                                    // Возвращает результат
}

int[,] FillArray(int numLine, int numColumns, int minRand = 0, int maxRand = 10)         // Функция создания и заполнения двумерного массива случайными числами  
{
    int[,] matrix = new int[numLine, numColumns];
    for (int i = 0; i < matrix.GetLength(0); i++)   // Строка
    {
        for (int j = 0; j < matrix.GetLength(1); j++)     // Столбец
        {
            matrix[i, j] = new Random().Next(minRand, maxRand);      // [0; 10) по умолчанию 
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

int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)  // Функция умножения матриц
{
    int[,] product = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); ++i)
    {
        for (int j = 0; j < matrix2.GetLength(1); ++j)
        {
            product[i, j] = 0;
            for (int k = 0; k < matrix1.GetLength(1); ++k)
                product[i, j] += matrix1[i, k] * matrix2[k, j];
        }
    }
    return product;
}

void Main()
{
    int a = Prompt("Введите число строк матрицы А ");
    int b = Prompt("Введите число столбцов матрицы А ");
    int c = Prompt("Введите число строк матрицы В ");
    int d = Prompt("Введите число столбцов матрицы В ");
    if (!(a > 0 && b > 0 && c > 0 && d > 0))
    {
        System.Console.WriteLine("Невозможно решить задачу с такими параметрами");
        return;
    }
    int[,] array1 = FillArray(a, b);
    int[,] array2 = FillArray(c, d);
    // int[,] array1 = {{2, 3, 0}, {1, 0, 4}};  // Массивы из википедии для проверки
    // int[,] array2 = {{1, 0}, {1, 4}, {0, 2}};
    // result = {{5, 12}, {1, 8}};              // Результат умножения 
    PrintArray(array1);
    System.Console.WriteLine();
    PrintArray(array2);
    System.Console.WriteLine();
    if (array1.GetLength(0) != array2.GetLength(1))
    {
        System.Console.WriteLine("Матрицы несовместимы");
        return;
    }
    int[,] result = MatrixMultiplication(array1, array2);
    PrintArray(result);
}

Main();