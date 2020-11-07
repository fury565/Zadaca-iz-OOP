using System;
using System.Collections.Generic;
using System.Text;

public class Description
{
    int brojep;
    TimeSpan vrijemeep;
    String nazivep;
    public Description(int broj,TimeSpan vrijeme,String naziv)
    {
        brojep = broj;
        vrijemeep = vrijeme;
        nazivep = naziv;
    }
    public override String ToString()
    {
        return brojep.ToString() +","+ vrijemeep.ToString() +","+ nazivep;
    }
    
}
