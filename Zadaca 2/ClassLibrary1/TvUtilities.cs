using System;
using System.Collections.Generic;
using System.Text;

public static class TvUtilities
{
	public static double GenerateRandomScore()
	{
		Random rnd = new Random();
		double score = rnd.NextDouble() * 10;
		return Math.Round(score, 5);
	}
	public static Episode Parse(string episode)
    {
		int viewercount=0;
		double ratingsum=0;
		double maxrating=0;
		int brojep=0;
		TimeSpan vrijemeep;
		String nazivep;
		int mjestoodvajanja = 0;
		int brojodvajanja = 0;
		string privremeni="";
		for(int i=0; i < episode.Length; i++)
        {
            if (episode[i] == ',')
            {
				for (int j = mjestoodvajanja; j < i; j++)
					privremeni += episode[j];
				if (brojodvajanja == 0)
					viewercount = Int32.Parse(privremeni);
				else if (brojodvajanja == 1)
					ratingsum = Double.Parse(privremeni);
				else if (brojodvajanja == 2)
					maxrating = Double.Parse(privremeni);
				else if (brojodvajanja == 3)
					brojep = Int32.Parse(privremeni);
				else if (brojodvajanja == 4)
					vrijemeep = TimeSpan.Parse(privremeni);
				brojodvajanja++;
				mjestoodvajanja = i + 1;
				privremeni = "";
            }
        }
		for (int j = mjestoodvajanja; j < episode.Length; j++)
			privremeni += episode[j];
		nazivep = privremeni;
		return new Episode(viewercount, ratingsum, maxrating, new Description(brojep, vrijemeep, nazivep));
	}
	public static void Sort(Episode[] episodes)
    {
		Episode priv;
		for(int i = 0; i < episodes.Length; i++)
        {
			for(int j = i + 1; j < episodes.Length; j++)
            {
                if (episodes[i] < episodes[j])
                {
					priv = episodes[i];
					episodes[i] = episodes[j];
					episodes[j] = priv;
                }
            }
        }
    }
}
