using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class Lab8T3
{
    public void Run()
    {
        Console.Write("Введи символ для пошуку: ");
        char targetChar = Console.ReadKey().KeyChar;
        Console.WriteLine();

        string inputPath = "input3.txt";
        string outputPath = "output3.txt";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Файл не знайдено.");
            return;
        }

        string text = File.ReadAllText(inputPath);

        var words = Regex.Matches(text, @"\b\w+\b")
                         .Cast<Match>()
                         .Select(m => m.Value)
                         .ToList();

        var wordCounts = words
            .Select(w => new { Word = w, Count = w.Count(c => c == targetChar) })
            .Where(x => x.Count > 0)
            .ToList();

        if (!wordCounts.Any())
        {
            Console.WriteLine($"Жодне слово не містить символ '{targetChar}'.");
            return;
        }

        int maxCount = wordCounts.Max(x => x.Count);

        var resultWords = wordCounts
            .Where(x => x.Count == maxCount)
            .Select(x => x.Word)
            .Distinct()
            .ToList();

        Console.WriteLine($"\nСлова з найбільшою кількістю символу '{targetChar}' ({maxCount} разів):");
        foreach (var w in resultWords)
            Console.WriteLine(w);

        File.WriteAllLines(outputPath, resultWords);
        Console.WriteLine($"\nРезультат записано у файл {outputPath}");
    }
}
