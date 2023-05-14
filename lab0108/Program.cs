using System;
using System.IO;

class Program
{
    static void Main()
    {
        string groupNumber = "KN1-B21"; 
        string lastName = "Стефура"; 

        string oopLab08Path = @"D:\OOP_lab08";
        Directory.CreateDirectory(oopLab08Path);
        Console.WriteLine("Каталог OOP_lab08 створений.");

        string groupPath = Path.Combine(oopLab08Path, groupNumber);
        string lastNamePath = Path.Combine(oopLab08Path, lastName);
        string sourcesPath = Path.Combine(oopLab08Path, "Sources");
        string reportsPath = Path.Combine(oopLab08Path, "Reports");
        string textsPath = Path.Combine(oopLab08Path, "Texts");

        Directory.CreateDirectory(groupPath);
        Directory.CreateDirectory(lastNamePath);
        Directory.CreateDirectory(sourcesPath);
        Directory.CreateDirectory(reportsPath);
        Directory.CreateDirectory(textsPath);

        Console.WriteLine("Каталоги створені.");

        string textsDestinationPath = Path.Combine(lastNamePath, "Texts");
        string sourcesDestinationPath = Path.Combine(lastNamePath, "Sources");
        string reportsDestinationPath = Path.Combine(lastNamePath, "Reports");

        DirectoryCopy(textsPath, textsDestinationPath, true);
        DirectoryCopy(sourcesPath, sourcesDestinationPath, true);
        DirectoryCopy(reportsPath, reportsDestinationPath, true);

        Console.WriteLine("Каталоги Texts, Sources та Reports скопійовані.");

        string groupDestinationPath = Path.Combine(groupPath, lastName);

        Directory.Move(lastNamePath, groupDestinationPath);

        Console.WriteLine("Каталог з прізвищем переміщений до каталогу з номером групи.");

        string dirInfoFilePath = Path.Combine(textsPath, "dirinfo.txt");

        using (StreamWriter writer = new StreamWriter(dirInfoFilePath))
        {
            writer.WriteLine("Інформація про каталог Texts:");
            writer.WriteLine("----------------------------");
            writer.WriteLine("Шлях: " + textsPath);
            writer.WriteLine("Дата створення: " + Directory.GetCreationTime(textsPath));
            writer.WriteLine("Кількість файлів: " + Directory.GetFiles(textsPath).Length);
            writer.WriteLine("Кількість підкаталогів: " + Directory.GetDirectories(textsPath).Length);
            writer.WriteLine("----------------------------");
        }

        Console.WriteLine("Файл dirinfo.txt створений у каталозі Texts.");

        Console.WriteLine("Операції з файловою системою завершено.");
    }

    static void DirectoryCopy(string sourceDir, string destDir, bool copySubDirs)
    {
        DirectoryInfo dir = new DirectoryInfo(sourceDir);
        DirectoryInfo[] dirs = dir.GetDirectories();

        Directory.CreateDirectory(destDir);

        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDir, file.Name);
            file.CopyTo(temppath, false);
        }
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDir, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }
}