using System;
using System.IO;

public class Lab8T5
{
    public void Run()
    {
        string basePath = @"C:\tmp";
        string folder1 = Path.Combine(basePath, "Скидан1");
        string folder2 = Path.Combine(basePath, "Скидан2");

        // 1. Створення папок
        Directory.CreateDirectory(folder1);
        Directory.CreateDirectory(folder2);

        string t1Path = Path.Combine(folder1, "t1.txt");
        string t2Path = Path.Combine(folder1, "t2.txt");

        File.WriteAllText(t1Path, "<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>");
        File.WriteAllText(t2Path, "<Комар Сергій Федорович, 2000 > року народження, місце проживання <м. Київ>");


        string t3Path = Path.Combine(folder2, "t3.txt");
        File.WriteAllText(t3Path, File.ReadAllText(t1Path) + Environment.NewLine + File.ReadAllText(t2Path));

        Console.WriteLine("Інформація про створені файли:");
        PrintFileInfo(t1Path);
        PrintFileInfo(t2Path);
        PrintFileInfo(t3Path);

        string movedT2 = Path.Combine(folder2, "t2.txt");
        File.Move(t2Path, movedT2);

        string copiedT1 = Path.Combine(folder2, "t1.txt");
        File.Copy(t1Path, copiedT1, true);

        string allPath = Path.Combine(basePath, "ALL");
        if (Directory.Exists(allPath)) Directory.Delete(allPath, true);
        Directory.Move(folder2, allPath);
        Directory.Delete(folder1, true);

        Console.WriteLine("\nФайли в папці ALL:");
        foreach (string file in Directory.GetFiles(allPath))
        {
            PrintFileInfo(file);
        }

        Console.WriteLine("\nГотово!");
    }

    private void PrintFileInfo(string path)
    {
        FileInfo file = new FileInfo(path);
        Console.WriteLine($"{file.Name} | {file.FullName}");
        Console.WriteLine($"  Розмір: {file.Length} байт");
        Console.WriteLine($"  Створено: {file.CreationTime}");
        Console.WriteLine($"  Змінено: {file.LastWriteTime}");
        Console.WriteLine();
    }
}
