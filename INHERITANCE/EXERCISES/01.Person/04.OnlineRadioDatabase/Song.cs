using System;
using System.Collections.Generic;
using System.Text;

public class Song
{
    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        ArtistName = artistName;
        SongName = songName;
        Minutes = minutes;
        Seconds = seconds;
    }

    public string ArtistName
    {
        get { return artistName; }
        set { artistName = Validator.ValidateArtistName(value); }
    }
    public string SongName
    {
        get { return songName; }
        set { songName = Validator.ValidateSongName(value); }
    }
    public int Minutes
    {
        get { return minutes; }
        set { minutes = Validator.ValidateSongMinutes(value); }
    }

    public int Seconds
    {
        get { return seconds; }
        set { seconds = Validator.ValidateSongSeconds(value); }
    }
    
    public int CalculateSongLength()
    {
        return this.minutes * 60 + this.seconds;
    }

}
