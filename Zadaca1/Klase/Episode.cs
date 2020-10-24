using System;

public class Episode
{
    private int viewercount;
    private double ratingsum;
    private double maxrating;

    public Episode() { }
    public Episode(int viewercount, double ratingsum, double maxrating)
    {
        this.viewercount = viewercount;
        this.ratingsum = ratingsum;
        this.maxrating = maxrating;
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
}
