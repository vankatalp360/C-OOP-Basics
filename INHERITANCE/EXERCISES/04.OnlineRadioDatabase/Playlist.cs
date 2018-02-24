using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Playlist
{
    private List<Song> songs;
    private int NumberOfSongs => songs.Count;
    private int[] TotalPlaylistLength => CalculatePlaylistLength();


    public Playlist()
    {
        songs = new List<Song>();
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Songs added: {NumberOfSongs}");
        builder.AppendLine(
            $"Playlist length: {TotalPlaylistLength[0]}h {TotalPlaylistLength[1]}m {TotalPlaylistLength[2]}s");
        return builder.ToString().TrimEnd();
    }

    public void AddSong(Song song)
    {
        songs.Add(song);
        Console.WriteLine($"Song added.");
    }
    private int[] CalculatePlaylistLength()
    {
        long totalLengthSeconds = songs.Sum(s => s.CalculateSongLength());
        var playlistLength = new int[3]; // h : mm: ss
        var index = playlistLength.Length - 1;
        while (totalLengthSeconds > 0 && index >= 0)
        {
            playlistLength[index--] = (int)(totalLengthSeconds % 60);
            totalLengthSeconds /= 60;
        }
        return playlistLength;
    }
}
