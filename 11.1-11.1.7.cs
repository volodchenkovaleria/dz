using System; 
using System.Text.RegularExpressions; // Подключаем пространство имен для работы с регулярными выражениями

class Program // Основной класс программы.
{
    private static char firstDigit;

    static void Main(string[] args) // Метод, выполняемый при запуске программы, где тестируются различные строки.
    {
        // Примеры строк для тестирования
        string[] testStrings = { "000", "1010", "110", "123", "222", "456789", "789456", "112233" }; // объявляю массив строк testStrings, со строками для тестирования

        foreach (var str in testStrings) // цикл, который проходит по каждому элементу в массиве testStrings. Для каждой строки в массиве создается переменная str, представляющая текущую строку.
        {
            Console.WriteLine($"Строка: '{str}': "); // печатает текущую строку в консоль

            Console.WriteLine($"Три нуля подряд: {IsMatchThreeZeros(str)}"); 
            Console.WriteLine($"Сочетание символов '101': {IsMatchConsecutiveOnes(str)}");
            Console.WriteLine($"Начинается/заканчивается на '101': {IsMatchStartsEndsWith101(str)}");
            Console.WriteLine($"Строки из цифр, содержащие '1': {IsMatchContainsOne(str)}");
            Console.WriteLine($"Строки из цифр, не содержащие '1': {IsMatchNotContainsOne(str)}");
            Console.WriteLine($"Первая цифра встречается где-то еще: {IsMatchFirstDigitOccursElsewhere(str)}");
            Console.WriteLine($"Первая цифра больше нигде не встречается: {IsMatchFirstDigitAppearsOnlyFirst(str)}");
            Console.WriteLine();
        }
    }

    // 1. Строки, содержащие три нуля подряд
    static bool IsMatchThreeZeros(string input) // метод, который принимает строку input и возвращает логическое значение (bool). Метод проверяет, содержит ли строка три нуля подряд.
    {
        // ^- начало строки.

        // *-позволяет любым символам(кроме символа перевода строки) повторяться 0 или более раз.

        // 000 - конкретная последовательность из трех нулей.

        // *$ -позволяет любым символам(кроме символа перевода строки) повторяться 0 или более раз до конца строки.
        string patternFull = @"^.*000.*$"; // Полное регулярное выражение для трех нулей
        string patternPart = @"000"; // Определяет часть строки, которая будет искаться в input. В данном случае, это просто "000".
        return Regex.IsMatch(input, patternFull) || Regex.IsMatch(input, patternPart); // Возвращает true, если input соответствует хотя бы одному из регулярных выражений.Метод Regex.IsMatch проверяет, соответствует ли строка заданному шаблону.
    }

    // 2. Строки, содержащие сочетание символов 101
    static bool IsMatchConsecutiveOnes(string input)
    {
        string patternFull = @"^.*101.*$"; // Полное регулярное выражение для 101
        string patternPart = @"101"; // Часть регулярного выражения для 101
        return Regex.IsMatch(input, patternFull) || Regex.IsMatch(input, patternPart); // Возвращает true, если input соответствует хотя бы одному из регулярных выражений. Метод Regex.IsMatch проверяет, соответствует ли строка заданному шаблону.
    }

    // 3. Строки, начинающиеся или заканчивающиеся на сочетание символов 101
    static bool IsMatchStartsEndsWith101(string input)
    {
        string patternFull = @"^101.*|.*101$"; // Полное регулярное выражение для начала или конца с 101
        return Regex.IsMatch(input, patternFull);
    }

    // 4. Строки из цифр, содержащие 1
    static bool IsMatchContainsOne(string input)
    {
        string patternFull = @"^\d*1\d*$"; // выражение ^\d1\d$ находит строки, содержащие хотя бы одну единицу (1) и состоящие только из цифр.\d - соответствует любой цифре (0–9).

        return Regex.IsMatch(input, patternFull);
    }

    // 5. Строки из цифр, не содержащие 1
    static bool IsMatchNotContainsOne(string input)
    {
        string patternFull = @"^\D*|[^1]*$"; // Полное регулярное выражение для цифр без 1, ^\d$ с условием [^1] внутри для проверки отсутствие единиц.

        return Regex.IsMatch(input, patternFull);
    }

    // 6. Непустые строки из цифр, первая цифра встречается где-то еще
    static bool IsMatchFirstDigitOccursElsewhere(string input)
    {
        if (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, @"^\d+$")) return false; // П сначала проверяет, является ли строка пустой или содержит что-то кроме цифр (с помощью регулярного выражения @"^\d+$").
        char firstDigit = input[0];
        return Regex.IsMatch(input.Substring(1), firstDigit.ToString()); // Ищем первую цифру в остальной части строки
    }

    // 7. Непустые строки из цифр, первая цифра больше нигде не встречается
    static bool IsMatchFirstDigitAppearsOnlyFirst(string input)
    {
        if (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, @"^\d+$")) return false; // Сначала делается аналогичная проверка на пустоту и составность.
        return input.IndexOf(firstDigit) == input.LastIndexOf(firstDigit); // Проверяем, встречается ли первая цифра только один раз, Сравниваются индексы вхождения первой цифры.
    }
}

