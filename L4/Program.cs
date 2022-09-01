/*  Напишите программу, которая заполнит спирально квадратный массив. */

int Prompt(string message)
{
    System.Console.Write(message);                    // Вывести сообщение
    int result = Convert.ToInt32(Console.ReadLine()); // Считывает значение
    return result;                                    // Возвращает результат
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

int[,] SpiralArray(int m, int n)        // Функция заполнения двумерного массива по спирали
{
    int[,] array = new int[m, n];       // Создаем массив заданной размерности, заполняем 0
    int rowBegin = 0;                   // Начало старта по строкам    
    int rowEnd = m - 1;                 // Граница строки
    int colBegin = 0;                   // Начало старта по столбцам    
    int colEnd = n - 1;                 // Граница столбца
    int count = m * n;                  // Количество элементов в матрице
    int value = 1;                      // Значение элемента с нарастанием 1..m*n
    int i = 0;
    int j = 0;
    while (count > 0)
    {
        for (j = colBegin; j <= colEnd; j++)    // слева направо
        {
            array[i, j] = value++;
            count--;
        }
        j--;                                    // коррекция счетчика
        rowBegin++;
        for (i = rowBegin; i <= rowEnd; i++)    // сверху вниз
        {
            array[i, j] = value++;
            count--;
        }
        i--;                                    // коррекция счетчика
        colEnd--;
        for (j = colEnd; j >= colBegin; j--)    // справа налево
        {
            array[i, j] = value++;
            count--;
        }
        j++;                                    // коррекция счетчика
        rowEnd--;
        for (i = rowEnd; i >= rowBegin; i--)    // снизу вверх   
        {
            array[i, j] = value++;
            count--;
        }
        i++;                                    // коррекция счетчика
        colBegin++;
    }
    return array;
}

void Main()
{
    int m = Prompt("Введите количество строк массива ");
    int n = Prompt("Введите количество столбцов массива ");
    if (m < 1 || n < 1)
    {
        System.Console.WriteLine("Значения заданы неверно");
        return;
    }
    int[,] array = SpiralArray(m, n);
    PrintArray(array);
}

Main();