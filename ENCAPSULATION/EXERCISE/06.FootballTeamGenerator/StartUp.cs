using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var teams = new List<Team>();
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            var inputArgs = input.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            var command = inputArgs[0];

            try
            {
                switch (command.ToLower())
                {
                    case "team": AddTeam(teams, inputArgs);
                        break;
                    case "add": AddPlayer(teams, inputArgs);
                        break;
                    case "remove": RemovePlayer(teams, inputArgs);
                        break;
                    case "rating": ShowTeamRating(teams, inputArgs);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void ShowTeamRating(List<Team> teams, string[] inputArgs)
    {
        var name = inputArgs[1];
        var team = Validator.CheckTeamExist(teams, name);
        Console.WriteLine(team);
    }

    private static void RemovePlayer(List<Team> teams, string[] inputArgs)
    {
        var teamName = inputArgs[1];
        var team = Validator.CheckTeamExist(teams, teamName);
        var playerName = inputArgs[2];
        team.RemovePlayers(playerName);
    }

    private static void AddPlayer(List<Team> teams, string[] inputArgs)
    {
        var teamName = inputArgs[1];
        var team = Validator.CheckTeamExist(teams, teamName);
        var playerName = inputArgs[2];
        var endurance = int.Parse(inputArgs[3]);
        var sprint = int.Parse(inputArgs[4]);
        var dribble = int.Parse(inputArgs[5]);
        var passing = int.Parse(inputArgs[6]);
        var shooting = int.Parse(inputArgs[7]);
        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
        team.AddPlayers(player);
    }

    private static void AddTeam(List<Team> teams, string[] inputArgs)
    {
        var name = inputArgs[1];
        var team = new Team(name);
        teams.Add(team);
    }
}
