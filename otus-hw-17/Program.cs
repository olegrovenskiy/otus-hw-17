using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

Console.WriteLine("Hello, World!");

string dirName = "C:\\Users\\o.rovenskiy\\source\\repos\\otus-hw-17\\otus-hw-17\\otus-hw-17\\bin\\Debug\\net7.0\\";



var test = new FileInDirectory(dirName);

test.FileFoundEvent += DisplayMessage;

test.GetFile();








Console.ReadKey();


void DisplayMessage(string message) => Console.WriteLine(message);

public class FileInDirectory
{
    public delegate void FileHandler(string message);
    public event FileHandler FileFoundEvent;
    public string dirPath { get; set; }

    public FileInDirectory(string _dirPath)
    {
        dirPath = _dirPath;
    }

    public void GetFile ()
    {
        string[] files = Directory.GetFiles(dirPath);

        foreach (string s in files)
        {
            if (s != null)
            {
                FileFoundEvent?.Invoke($"Файл найден, имя - : {s}");
            }
        }
    }

}





