using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Team
{
    private string name;
    private List<Player> players;
    private int rating => CalculateRating();

    public string Name
    {
        get => name;
        set => name = Validator.ValidateName(value);
    }

    public Team(string name)
    {
        this.name = name;
        players = new List<Player>();
    }


    public override string ToString()
    {
        return $"{name} - {rating}";
    }

    public void AddPlayers(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayers(string name)
    {
        players.Remove(Validator.CheckPlayerContains(this.name, players, name));
    }
    private int CalculateRating()
    {
        if (players.Any())
        {
            decimal rating = players.Sum(p => p.Stats);
            rating /= players.Count;
            return (int) Math.Round(rating);
        }
        else
        {
            return 0;
        }
    }
}
