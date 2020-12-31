using System;
using System.Collections.Generic;
using System.Text;

public class TvException:Exception
{
    public string Title { get; private set; }
    public string Message { get; private set; }
    public TvException()
    {
        Title = "null";
        Message = "null";
    }
    public TvException(string name)
    {
        Title = name;
        Message = "Episode not found!";
    }
}
