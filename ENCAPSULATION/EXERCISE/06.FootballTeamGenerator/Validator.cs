using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Validator
{
    public static string ValidateName(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            return name;
        }
        throw new ArgumentException($"A name should not be empty.");
    }

    public static int ValidateStats(string statusName, int status)
    {
        if (status >= 0 && status <= 100)
        {
            return status;
        }
        throw new ArgumentException($"{statusName} should be between 0 and 100.");
    }

    public static Player CheckPlayerContains(string teamName, List<Player> players, string name)
    {
        var contains = players.FirstOrDefault(p => p.Name == name);
        if (contains != null)
        {
            return contains;
        }
        throw new ArgumentException($"Player {name} is not in {teamName} team.");
    }

    public static Team CheckTeamExist(List<Team> teams, string name)
    {
        var contains = teams.FirstOrDefault(t => t.Name == name);
        if (contains == null)
        {
            throw new ArgumentException($"Team {name} does not exist.");
        }
        return contains;
    }
}
