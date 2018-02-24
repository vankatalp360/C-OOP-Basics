using System;
using System.Collections.Generic;
using System.Text;

public class Validator
{
    public static string ValidateArtistName(string name)
    {
        if (name.Length < 3 || name.Length > 20)
        {
            throw new InvalidArtistNameException();
        }
        return name;
    }

    public static string ValidateSongName(string name)
    {
        if (name.Length < 3 || name.Length > 30)
        {
            throw new InvalidSongNameException();
        }
        return name;
    }

    public static int ValidateSongMinutes(int minutes)
    {
        if (minutes < 0 || minutes > 14)
        {
            throw new InvalidSongMinutesException();
        }
        return minutes;
    }

    public static int ValidateSongSeconds(int seconds)
    {
        if (seconds < 0 || seconds > 59)
        {
            throw new InvalidSongSecondsException();
        }
        return seconds;
    }
}
