class Program // Определение класса Program
{
    static void Main(string[] args) // Основной метод, с которого начинается выполнение программы
    {
        int N = 5; // Размерность массива (N x N). Это нечетное число, что позволяет точно определить центр массива.

        int[,] array = new int[N, N]; // Создаем двумерный массив array размером N x N.

        // Заполним массив числами от 1 до N*N
        for (int i = 0; i < N; i++) // Внешний цикл (по i) проходит по строкам массива.

        {
            for (int j = 0; j < N; j++) // Внутренний цикл (по j) проходит по столбцам массива.

            {
                array[i, j] = i * N + j + 1; // Каждая ячейка массива заполняется числами от 1 до N*N. 
            }
        }

        // Вызов функции обхода спирали
        SpiralPrint(array, N); // Вызов функции SpiralPrint, передавая массив и его размер N.

    }

    static void SpiralPrint(int[,] array, int N) // Определение метода SpiralPrint, который будет выполнять обход массива по спирали.
    {
        int centerX = N / 2; // Находим координату центра по оси X, это будет 2 для N = 5.
        int centerY = N / 2; // Координата центра по оси Y
        Console.WriteLine(array[centerY, centerX]); // Выводим центр массива

        // Определяем количество шагов по спирали
        for (int layer = 1; layer <= N / 2; layer++) // Мы используем переменную layer, которая будет представлять уровне обхода
        {
            // Обход по правой стороне
            for (int i = 1; i <= layer * 2; i++)
                Console.WriteLine(array[centerY - layer + i, centerX + layer]);

            // Обход по нижней стороне
            for (int i = 1; i <= layer * 2; i++)
                Console.WriteLine(array[centerY + layer, centerX + layer - i]);

            // Обход по левой стороне
            for (int i = 1; i <= layer * 2; i++)
                Console.WriteLine(array[centerY + layer - i, centerX - layer]);

            // Обход по верхней стороне
            for (int i = 1; i <= layer * 2; i++)
                Console.WriteLine(array[centerY - layer, centerX - layer + i]);
        }
    }
}