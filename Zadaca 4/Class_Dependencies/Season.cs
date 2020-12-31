using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Season : IEnumerable<Episode>
{
    int seasonnumber;
    List<Episode> seasonepisodes;
    public int Length { get { return seasonepisodes.Count; } }
    public Season()
    {
        seasonnumber = 0;
        seasonepisodes = new List<Episode>();
    }
    public Season(int seasonnumber,List<Episode> seasonepisodes)
    {
        this.seasonepisodes = new List<Episode>(seasonepisodes);
        this.seasonnumber = seasonnumber;
    }
    public Season(Season original)
    {
        seasonepisodes = new List<Episode>();
        foreach (var episode in original)
        {
            string[] lines = episode.ToString().Split(',');
            int viewercount = Int32.Parse(lines[0]);
            double scoresum = Double.Parse(lines[1]);
            double maxscore = Double.Parse(lines[2]);
            int episodenumber = Int32.Parse(lines[3]);
            TimeSpan duration = TimeSpan.Parse(lines[4]);
            string name = lines[5];
            seasonepisodes.Add(new Episode(viewercount, scoresum, maxscore, new Description(episodenumber, duration, name)));
        }
        seasonnumber = original.seasonnumber;
    }
    public void Add(Episode episode)
    {
        seasonepisodes.Add(episode);
    }
    public void Remove(string name)
    {
        int removed = 0;
        for(int i=0;i<seasonepisodes.Count;i++)
        {
            if (seasonepisodes[i].ToString().Contains(name))
            {
                seasonepisodes.Remove(seasonepisodes[i]);
                removed = 1;
            }
        }
        if(removed==0)
            throw new TvException(name);
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
    
    IEnumerator<Episode> IEnumerable<Episode>.GetEnumerator()
    {
        return ((IEnumerable<Episode>)seasonepisodes).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)seasonepisodes).GetEnumerator();
    }
}
