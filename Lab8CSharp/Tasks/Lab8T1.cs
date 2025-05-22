using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Lab8T1
{
    private string inputPath = "input.txt";
    private string outputPath = "output.txt";
    private string pattern = @"[\(\[\{]?-?\d+(\.\d+)?\s*[,;\s]\s*-?\d+(\.\d+)?[\)\]\}]?";

    public void Run()
    {
        ProcessFile();
    }

    private void ProcessFile()
    {
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Файл не знайдено.");
            return;
        }

        string text = File.ReadAllText(inputPath);

        MatchCollection matches = Regex.Matches(text, pattern);
        Console.WriteLine($"Знайдено {matches.Count} векторів:");

        List<string> vectors = new List<string>();
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
            vectors.Add(match.Value);
        }

        Console.Write("Введи рядок, який замінити: ");
        string toReplace = Console.ReadLine();
        Console.Write("Введи на що замінити: ");
        string replacement = Console.ReadLine();

        string replacedText = text.Replace(toReplace, replacement);

        File.WriteAllText(outputPath, replacedText);
        Console.WriteLine($"Записано у файл: {outputPath}");
    }
}
