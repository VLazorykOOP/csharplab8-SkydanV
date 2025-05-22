using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

public class Lab8T2
{
    private string inputPath = "input2.txt";
    private string outputPath = "output2.txt";

    public async Task Run()
    {
        Console.WriteLine("Шукаю файл за шляхом: " + Path.GetFullPath(inputPath));

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Файл input2.txt не знайдено.");
            return;
        }

        string text = await File.ReadAllTextAsync(inputPath);

        var matches = Regex.Matches(text, @"\b[_a-zA-Z][_a-zA-Z0-9]*\b");

        if (matches.Count == 0)
        {
            Console.WriteLine("Ідентифікаторів не знайдено.");
            await File.WriteAllTextAsync(outputPath, "Ідентифікаторів не знайдено.");
            return;
        }

        string result = string.Join(" ", matches.Select(m => m.Value));

        Console.WriteLine("Знайдені ідентифікатори:");
        Console.WriteLine(result);

        await File.WriteAllTextAsync(outputPath, result);

        Console.WriteLine($"Результат записано у файл {outputPath}");
    }
}
