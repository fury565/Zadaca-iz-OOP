using System;
using System.Collections.Generic;
using System.Text;

public class Season
{
    int seasonnumber;
    List<Episode> seasonepisodes;
    public int Length { get; private set; }
    public Season()
    {
        seasonnumber = 0;
        seasonepisodes = new List<Episode>();
        Length = 0;
    }
    public Season(int seasonnumber,Episode[] seasonepisodes)
    {
        this.seasonepisodes = new List<Episode>(seasonepisodes);
        this.seasonnumber = seasonnumber;
        Length = seasonepisodes.Length;
    }
    public Episode this[int key]
    {
        get => seasonepisodes[key];
    }
    public override string ToString()
    {
        int views = 0;
        TimeSpan totalduration = TimeSpan.Zero;
        string output = $"Season {seasonnumber}:\n=====================================\n";
        for (int i = 0; i < seasonepisodes.Count; i++) {
            output += seasonepisodes[i] + "\n";
            views += seasonepisodes[i].GetViewerCount();
            totalduration += seasonepisodes[i].GetDuration();
        }
        output += $"Report:\n===================================\nViewer Count:{views}\nTotal Duration:{totalduration}\n===============================\n";
        return output;
    }
}
