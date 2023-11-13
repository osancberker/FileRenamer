using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string folderPath = @"Your Local Folder Path";

        string[] fileList = Directory.GetFiles(folderPath);

        foreach (var filePath in fileList)
        {
            EditAndRename(filePath);
        }

        Console.WriteLine("Operation completed. Press any key to close the program.");
        Console.ReadKey();
    }

    static void EditAndRename(string filePath)
    {
        try
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string fileExtension = Path.GetExtension(filePath);

            string editedName = string.Join("-", fileName.Split(' ')).ToLower();

            editedName = TurkishToEnglish(editedName);

            string newFileName = $"{editedName}{fileExtension}";

            File.Move(filePath, Path.Combine(Path.GetDirectoryName(filePath), newFileName));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static string TurkishToEnglish(string text)
    {
        string[] turkishCharacters = { "ğ", "ü", "ş", "ı", "i", "ö", "ç", "Ğ", "Ü", "Ş", "I", "İ", "Ö", "Ç" };
        string[] englishCharacters = { "g", "u", "s", "i", "i", "o", "c", "G", "U", "S", "I", "I", "O", "C" };

        for (int i = 0; i < turkishCharacters.Length; i++)
        {
            text = text.Replace(turkishCharacters[i], englishCharacters[i]);
        }

        return text;
    }
}
