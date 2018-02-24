using System;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var songsNumber = int.Parse(Console.ReadLine());
        var playlist = new Playlist();
        ReadSongs(songsNumber, playlist);
        try
        {
            
        }
        catch (InvalidSongException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine(playlist);
    }

    private static void ReadSongs(int songsNumber, Playlist playlist)
    {
        for (int i = 0; i < songsNumber; i++)
        {
            try
            {
                var songArgs = Console.ReadLine().Split(new[] {';'});
                var artist = songArgs[0];
                var songName = songArgs[1];
                int songMinutes = 0;
                int songSeconds = 0;
                try
                {
                    var songDuration = songArgs[2]
                        .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
                    songMinutes = songDuration[0];
                    songSeconds = songDuration[1];
                }
                catch
                {
                    throw new InvalidSongLengthException();
                }
                var song = new Song(artist, songName, songMinutes, songSeconds);
                playlist.AddSong(song);
            }
            catch (InvalidSongException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
