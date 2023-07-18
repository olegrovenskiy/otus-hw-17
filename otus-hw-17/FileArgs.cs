using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FileArgs : EventArgs
{
    public string FileName { get; set; }

    public FileArgs(string fileName)
    {
        FileName = fileName;
    }
}
