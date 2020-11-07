using System;

public class Episode
{
    private int viewercount;
    private double ratingsum;
    private double maxrating;
    private Description opisep;

    public Episode() { }
    public Episode(int viewercount, double ratingsum, double maxrating, Description opis)
    {
        this.viewercount = viewercount;
        this.ratingsum = ratingsum;
        this.maxrating = maxrating;
        opisep = opis;
    }
    public void AddView(double score)
    {
        viewercount++;
        ratingsum += score;
        if (maxrating < score)
            maxrating = score;
    }
    public double GetAverageScore()
    {
        return ratingsum / viewercount;
    }
    public string GetMaxScore()
    {
        return maxrating.ToString();
    }
    public int GetViewerCount()
    {
        return viewercount;
    }
    public override string ToString()
    {
        return viewercount.ToString()+","+ratingsum.ToString()+","+maxrating.ToString()+","+opisep.ToString();
    }
    public static bool operator<(Episode ep1,Episode ep2)
    {
        return (ep1.ratingsum / ep1.viewercount) < (ep2.ratingsum / ep2.viewercount);
    }
    public static bool operator >(Episode ep1, Episode ep2)
    {
        return (ep1.ratingsum / ep1.viewercount) > (ep2.ratingsum / ep2.viewercount);
    }
}
