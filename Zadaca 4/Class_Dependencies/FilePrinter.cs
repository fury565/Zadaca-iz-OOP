using System;
using System.Collections.Generic;
using System.IO;


public class FilePrinter:IPrinter
{
    string outputfile;
    public FilePrinter(string outputfile)
    {
        this.outputfile = outputfile;
    }

    public void Print(string towrite)
    {
        File.WriteAllText(outputfile, towrite);
    }
}
