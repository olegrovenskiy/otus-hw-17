using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

Console.WriteLine("Hello, World!");

string dirName = "C:\\Users\\o.rovenskiy\\source\\repos\\otus-hw-17\\otus-hw-17\\otus-hw-17\\bin\\Debug\\net7.0\\";

//public int FoundResult = 0;

var test = new FileInDirectory(dirName);

//test.FileFound += FileEventHandler;



test.GetFile();








Console.ReadKey();


//void DisplayMessage(string message) => Console.WriteLine(message);

/*
static void FileEventHandler(object sender, FileArgs e)
{
   
    Console.WriteLine($"File found {e.FileName}");
    if (e.FileName.Contains("exe"))
    {
        Console.WriteLine("One file *.exe");
        
    }

}

*/


public class FileInDirectory
{
    public delegate void EventHandler (object sender, FileArgs e);

    public event EventHandler FileFound;

    public int FoundResult = 0;

    public string dirPath { get; set; }
    public int Check = 0;
    public FileInDirectory(string _dirPath)
    {
        dirPath = _dirPath;
        this.FileFound += FileEventHandler;
    }


    public void FileEventHandler(object sender, FileArgs e)
    {

        Console.WriteLine($"File found {e.FileName}");
        if (e.FileName.Contains("exe"))
        {
            Console.WriteLine("One file *.exe");
            FoundResult = 1;
        }

    }






    public void GetFile ()
    {
        string[] files = Directory.GetFiles(dirPath);

        foreach (string s in files)
        {
            if (s != null)
            {
                FileFound?.Invoke(this, new FileArgs(s));
                
            }
            if (FoundResult == 1)
                break;
        }
    }

}

public class FileArgs : EventArgs
{
    public string FileName {get; set;}

    public FileArgs (string fileName)
    {
        FileName = fileName;
    }   
}





