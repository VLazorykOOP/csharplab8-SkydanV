using System;
using System.IO;
using System.Text;

public class Lab8T4
{
    public void Run()
    {
        string filePath = "output4.bin";

        Console.Write("¬вед≥ть пропозиц≥ю: ");
        string sentence = Console.ReadLine();

        string filtered = "";
        foreach (char c in sentence)
        {
            if (!char.IsDigit(c))
                filtered += c;
        }

        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            writer.Write(Encoding.UTF8.GetBytes(filtered));
        }

        Console.WriteLine($"\n¬м≥ст файлу {filePath} без цифр:");

        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            byte[] data = reader.ReadBytes((int)reader.BaseStream.Length);
            string result = Encoding.UTF8.GetString(data);
            Console.WriteLine(result);
        }
    }
}
