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
        Console.WriteLine("����� ���� �� ������: " + Path.GetFullPath(inputPath));

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("���� input2.txt �� ��������.");
            return;
        }

        string text = await File.ReadAllTextAsync(inputPath);

        var matches = Regex.Matches(text, @"\b[_a-zA-Z][_a-zA-Z0-9]*\b");

        if (matches.Count == 0)
        {
            Console.WriteLine("�������������� �� ��������.");
            await File.WriteAllTextAsync(outputPath, "�������������� �� ��������.");
            return;
        }

        string result = string.Join(" ", matches.Select(m => m.Value));

        Console.WriteLine("������� ��������������:");
        Console.WriteLine(result);

        await File.WriteAllTextAsync(outputPath, result);

        Console.WriteLine($"��������� �������� � ���� {outputPath}");
    }
}
