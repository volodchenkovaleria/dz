using System;

class Program
{
    static char[,] board = new char[3, 3]; // Игровое поле
    static char currentPlayer = 'X'; // Текущий игрок
    static Random random = new Random(); // Для случайных ходов компьютера

    static void Main()
    {
        InitializeBoard();
        Console.WriteLine("Выберите режим: 1 - Игрок против Игрока, 2 - Игрок против Компьютера");
        string choice = Console.ReadLine();
        if (choice == "1") PlayPlayerVsPlayer();
        else PlayPlayerVsComputer();
    }

    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                board[i, j] = ' '; // Заполнение доски пробелами
    }

    static void PlayPlayerVsPlayer()
    {
        while (true)
        {
            PrintBoard();
            PlayerMove();
            if (CheckWin()) { PrintBoard(); Console.WriteLine($"Игрок {currentPlayer} выиграл!"); break; }
            if (CheckDraw()) { PrintBoard(); Console.WriteLine("Ничья!"); break; }
            SwitchPlayer();
        }
    }

    static void PlayPlayerVsComputer()
    {
        while (true)
        {
            PrintBoard();
            if (currentPlayer == 'X') PlayerMove(); // Игрок ходит
            else ComputerMove(); // Компьютер ходит
            if (CheckWin()) { PrintBoard(); Console.WriteLine($"Игрок {currentPlayer} выиграл!"); break; }
            if (CheckDraw()) { PrintBoard(); Console.WriteLine("Ничья!"); break; }
            SwitchPlayer();
        }
    }

    static void PrintBoard()
    {
        Console.Clear();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($" {board[i, 0]} | {board[i, 1]} | {board[i, 2]} ");
            if (i < 2) Console.WriteLine("---|---|---");
        }
        Console.WriteLine();
    }

    static void PlayerMove()
    {
        int row, column;
        Console.WriteLine($"Игрок {currentPlayer}, введите строку и столбец (0, 1 или 2):");
        while (true)
        {
            row = int.Parse(Console.ReadLine());
            column = int.Parse(Console.ReadLine());
            if (row >= 0 && row < 3 && column >= 0 && column < 3 && board[row, column] == ' ')
            {
                board[row, column] = currentPlayer; // Установка знака текущего игрока
                break;
            }
            else Console.WriteLine("Некорректный ввод, попробуйте еще раз.");
        }
    }

    static void ComputerMove()
    {
        int row, column;
        do
        {
            row = random.Next(0, 3);
            column = random.Next(0, 3);
        } while (board[row, column] != ' '); // Ищем свободную клетку
        board[row, column] = currentPlayer; // Установка знака компьютера
    }

    static void SwitchPlayer() => currentPlayer = (currentPlayer == 'X') ? 'O' : 'X'; // Переключение игрока

    static bool CheckWin()
    {
        for (int i = 0; i < 3; i++)
            if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                return true;

        return (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
               (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer);
    }

    static bool CheckDraw()
    {
        foreach (char cell in board)
            if (cell == ' ') return false; // Есть свободная клетка
        return true; // Нет свободных клеток, значит ничья
    }
}