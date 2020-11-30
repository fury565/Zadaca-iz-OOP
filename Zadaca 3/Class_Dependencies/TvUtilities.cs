using System;
using System.Collections.Generic;
using System.IO;

public static class TvUtilities
{
	public static double GenerateRandomScore()
	{
		Random rnd = new Random();
		double score = rnd.NextDouble() * 10;
		return Math.Round(score, 3);
	}
	public static Episode Parse(string episode)
	{
		int viewercount = 0;
		double scoresum = 0;
		double maxscore = 0;
		int episodenumber = 0;
		TimeSpan duration;
		String name;
		int separatorindex = 0;
		int numberofseparations = 0;
		string temp = "";
		for (int i = 0; i < episode.Length; i++)
		{
			if (episode[i] == ',')
			{
				for (int j = separatorindex; j < i; j++)
					temp += episode[j];
				if (numberofseparations == 0)
					viewercount = Int32.Parse(temp);
				else if (numberofseparations == 1)
					scoresum = Double.Parse(temp);
				else if (numberofseparations == 2)
					maxscore = Double.Parse(temp);
				else if (numberofseparations == 3)
					episodenumber = Int32.Parse(temp);
				else if (numberofseparations == 4)
					duration = TimeSpan.Parse(temp);
				numberofseparations++;
				separatorindex = i + 1;
				temp = "";
			}
		}
		for (int j = separatorindex; j < episode.Length; j++)
			temp += episode[j];
		name = temp;
		return new Episode(viewercount, scoresum, maxscore, new Description(episodenumber, duration, name));
	}
	public static Episode[] LoadEpisodesFromFile(string filename)
    {
		Episode[] episodes = new Episode[10];
		string[] episodefile = File.ReadAllLines(filename);
		for(int i = 0; i < 10; i++)
        {
			episodes[i] = Parse(episodefile[i]);
        }
		return episodes;
    }
	public static void Sort(Episode[] episodes)
	{
		Episode temp;
		for (int i = 0; i < episodes.Length; i++)
		{
			for (int j = i + 1; j < episodes.Length; j++)
			{
				if (episodes[i] < episodes[j])
				{
					temp = episodes[i];
					episodes[i] = episodes[j];
					episodes[j] = temp;
				}
			}
		}
	}
}
