using System;
using System.Text;
using System.IO;


public class ConsolePrinter:IPrinter
{
    public ConsolePrinter()
    {

    }
    public void Print(string filename)
    {
        Console.WriteLine(filename);
    }
}

