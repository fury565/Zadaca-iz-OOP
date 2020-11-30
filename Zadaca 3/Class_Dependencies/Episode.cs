using System;

using System;

public class Episode
{
    private int viewercount;
    private double scoresum;
    private double maxscore;
    private Description episodedescript;

    public Episode()
    {
        viewercount = 0;
        scoresum = 0;
        maxscore = 0;
        episodedescript = new Description(0, TimeSpan.Zero, "UnNamed");
    }
    public Episode(int viewercount, double scoresum, double maxscore, Description episodedescript)
    {
        this.viewercount = viewercount;
        this.scoresum = scoresum;
        this.maxscore = maxscore;
        this.episodedescript = episodedescript;
    }
    public void AddView(double score)
    {
        viewercount++;
        scoresum += score;
        if (maxscore < score)
            maxscore = score;
    }
    public TimeSpan GetDuration()
    {
        return episodedescript.duration;
    }
    public double GetAverageScore()
    {
        return scoresum / viewercount;
    }
    public double GetMaxScore()
    {
        return maxscore;
    }
    public int GetViewerCount()
    {
        return viewercount;
    }
    public override string ToString()
    {
        return viewercount.ToString() + "," + scoresum.ToString() + "," + maxscore.ToString() + "," + episodedescript.ToString();
    }
    public static bool operator <(Episode ep1, Episode ep2)
    {
        return (ep1.scoresum / ep1.viewercount) < (ep2.scoresum / ep2.viewercount);
    }
    public static bool operator >(Episode ep1, Episode ep2)
    {
        return (ep1.scoresum / ep1.viewercount) > (ep2.scoresum / ep2.viewercount);
    }
}

