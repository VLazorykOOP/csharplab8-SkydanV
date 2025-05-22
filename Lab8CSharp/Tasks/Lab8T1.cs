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
            Console.WriteLine("���� �� ��������.");
            return;
        }

        string text = File.ReadAllText(inputPath);

        MatchCollection matches = Regex.Matches(text, pattern);
        Console.WriteLine($"�������� {matches.Count} �������:");

        List<string> vectors = new List<string>();
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
            vectors.Add(match.Value);
        }

        Console.Write("����� �����, ���� �������: ");
        string toReplace = Console.ReadLine();
        Console.Write("����� �� �� �������: ");
        string replacement = Console.ReadLine();

        string replacedText = text.Replace(toReplace, replacement);

        File.WriteAllText(outputPath, replacedText);
        Console.WriteLine($"�������� � ����: {outputPath}");
    }
}
