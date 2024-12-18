class Program // Объявляем класс Program
{
    static void Main(string[] args) // Объявляем основной метод Main
    {
        using (StreamWriter writer = new StreamWriter("f.txt")) // Создаем объект StreamWriter, для записи в файл f.txt. using закроет файл после завершения блока кода.
        {
            writer.WriteLine("x\tsin(x)"); // Записываем заголовок таблицы в файл. Использую \t, чтобы разделить значения с помощью табуляции.

            for (double x = 0; x <= 1; x += 0.1) // Начинаем цикл, который будет перебирать значения x от 0 до 1 с шагом 0.1.
            {
                writer.WriteLine($"{x:F1}\t{Math.Sin(x):F4}"); // Записываем значения x и sin(x) в файл, "{x:F1}" форматирует x до одного знака после запятой, а "{Math.Sin(x):F4}" форматирует sin(x) до четырех знаков после запятой.
            }
        }
    }
}