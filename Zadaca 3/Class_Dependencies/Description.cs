using System;
using System.Collections.Generic;
using System.Text;

public class Description
{
    public int episodenumber { get; private set; }
    public TimeSpan duration { get; private set; }
    protected String name { get; private set; }
    public Description(int episodenumber, TimeSpan duration, String name)
    {
        this.episodenumber = episodenumber;
        this.duration = duration;
        this.name = name;
    }
    public override String ToString()
    {
        return episodenumber.ToString() + "," + duration.ToString() + "," + name;
    }

}
