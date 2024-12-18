﻿using System;
using System.Diagnostics; // пространство имен, которое предоставляет классы для диагностики и взаимодействия с процессами, такими как измерение времени выполнения.


class Program // обьявление класса программы 
{
    static void Main(string[] args) // static означает, что метод принадлежит классу. void указывает на то, что метод не возвращает никакого значения. string[] args — массив строковых аргументов, передаваемых в метод из командной строки.

    {
        // Создание массива вопросов и ответов
        Question[] questions = new Question[] // создаёт массив объектов Question.
        {
            new Question("Какой язык программирования является наибольшим по популярности?", // создает экземпляры класса Question. В каждом вызове конструктора передаются текст вопроса, массив возможных ответов и индекс правильного ответа.
                new string[] { "C#", "JavaScript", "Python", "Ruby" },
                1),  // Индекс правильного ответа "JavaScript"
            new Question("Что такое OOP?",
                new string[] { "Процедурное программирование", "Объектно-ориентированное программирование",
                "Функциональное программирование", "Ничего из вышеупомянутого" },
                2),  // Индекс правильного ответа "Объектно-ориентированное программирование"
            new Question("Какой из этих типов данных является ссылочным?",
                new string[] { "int", "string", "bool", "char" },
                1),  // Индекс правильного ответа "string"
            new Question("Какой метод используется для вывода информации в консоль?",
                new string[] { "Console.ReadLine()", "Console.Write()",
                "Console.WriteLine()", "Console.Output()" },
                2),  // Индекс правильного ответа "Console.WriteLine()"
            new Question("Что такое инкапсуляция в ООП?",
                new string[] { "Скрытие данных", "Наследование",
                "Множественное наследование", "Полиморфизм" },
                0)   // Индекс правильного ответа "Скрытие данных"
        };

        int correctAnswers = 0;  // Счетчик правильных ответов
        Stopwatch stopwatch = new Stopwatch(); // создаём класс Stopwatch для отслеживания времени, затраченного на прохождение теста.

        Console.WriteLine("Тест по предмету. Ответьте на следующие вопросы:\n"); // выводит этот текст на консоль 

        stopwatch.Start();  // Запускаем таймер

        // Цикл для перебора вопросов
        for (int i = 0; i < questions.Length; i++) // цикл проходит по всем вопросам в массиве questions. Итерируем индекс i от 0 до длины массива.
        {
            Console.WriteLine($"{i + 1}. {questions[i].QuestionText}"); //выводит номер текущего вопроса и сам текст вопроса.
            for (int j = 0; j < questions[i].Answers.Length; j++) ;//  проходит по всем возможным ответам на текущий вопрос, и выводит их на экран.
        }
    }
}
// я пыталась 
