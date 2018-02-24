using System;
using System.Collections.Generic;
using System.Text;

public class Player
{
    private string name;
    private decimal stats => Math.Round((decimal)(endurance + sprint + dribble + passing + shooting) / 5);
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public string Name
    {
        get => name;
        set => name = Validator.ValidateName(value);
    }

    public decimal Stats => stats;

    private int Endurance
    {
        set => endurance = Validator.ValidateStats("Endurance", value);
    }
    private int Sprint
    {
        set => sprint = Validator.ValidateStats("Sprint", value);
    }
    private int Dribble
    {
        set => dribble = Validator.ValidateStats("Dribble", value);
    }
    private int Passing
    {
        set => passing = Validator.ValidateStats("Passing", value);
    }
    private int Shooting
    {
        set => shooting = Validator.ValidateStats("Shooting", value);
    }

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }
}
