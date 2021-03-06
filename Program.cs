﻿using System;
using System.IO;
using System.Threading;

class Roulette
{
    public static void Main()
    {
        string path = @"names.txt";
        if (File.Exists(path))
        {
            string input = "";
            Console.Write("Press Enter to run Roulette or 'q' to exit\n");
            while ((input = Console.ReadLine()) != "q")
            {
                var MaxLineLength = 0;
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Random random = new Random();
                string[] animation = { "| ", "/ ", "- ", "\\ " };
                string[] readText = File.ReadAllLines(path);
                Console.WriteLine(readText);
                int rand = random.Next(0, readText.Length - 1);
                Console.WriteLine("Our participants:\n");
                foreach (string line in readText)
                {
                    if (MaxLineLength < line.Length)
                    {
                        MaxLineLength = line.Length;
                    }
                    Console.WriteLine($" * {line}");
                    Thread.Sleep(50);
                }
                Console.Write("\nOur winner is: ");
                int origRow = Console.CursorTop;
                int origCol = Console.CursorLeft;
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50 + i * 5);
                    Console.Write(animation[i % animation.Length]);
                    Console.Write(
                        $"{readText[i % readText.Length]}"
                        + (new string(' ', MaxLineLength - readText[i % readText.Length].Length)));
                    Console.SetCursorPosition(origCol, origRow);
                }
                Console.WriteLine(new string(' ', MaxLineLength));
                Console.SetCursorPosition(origCol, origRow);
                Console.WriteLine($"*** {readText[rand]}! ***");
                Console.WriteLine("Press Enter to repeat or 'q' to exit");
            }
        }
        else
        {
            Console.WriteLine("File doesn't exist");
        }
    }
}