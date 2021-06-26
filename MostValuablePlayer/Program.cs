using MostValuablePlayer.Core;
using MostValuablePlayer.Sports;
using MostValuablePlayer.Stats;
using MostValuablePlayer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MostValuablePlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            // paths of the matches files
            // path exmaple: D:\Projects\MostValuablePlayerProblem\MostValuablePlayer\Data\Basketball.txt
            string[] paths =
            {
                @"D:\Projects\MostValuablePlayerProblem\MostValuablePlayer\Data\Basketball.txt",
                @"D:\Projects\MostValuablePlayerProblem\MostValuablePlayer\Data\Handball.txt",
            };

            // Dictionary of players, key = playerNickName (Unique), Value = instance of Player
            Dictionary<string, Player> players = new Dictionary<string, Player>();
            List<Match> matches = new List<Match>();

            // loop through files paths
            foreach (string path in paths)
            {
                // get lines from match file in path
                List<string> matchFileLines = InformationExtractor.ExtractLinesFromFile(path).ToList();
                
                // loop through match file lines  
                for (int i = 0; i < matchFileLines.Count; i++)
                {
                    // get sport name from first line of the file, and create match
                    if (i == 0)
                    {
                        string sportName = matchFileLines[0];
                        matches.Add(new Match(sportName));
                        continue;
                    }

                    // get raw player information from match file line
                    RawInfo rawPlayerInfo = InformationExtractor.ExtractInformationFromString(matchFileLines[i]);

                    // if players dictionary does not have playerNickName key, instantiate player and add it to dictionary  
                    if (players.ContainsKey(rawPlayerInfo.PlayerNickName) == false)
                    {
                        players[rawPlayerInfo.PlayerNickName] = new Player(rawPlayerInfo.PlayerName, rawPlayerInfo.PlayerNickName);
                    }

                    // add player to team in the current match, which returns player stats in the match
                    PlayerStats matchPlayerStats = matches.Last().AddPlayerToTeam(players[rawPlayerInfo.PlayerNickName], rawPlayerInfo);

                    // add match player's stats to player's overall stats record
                    players[rawPlayerInfo.PlayerNickName].AddPlayerStats(matchPlayerStats);
                }

                // On match ended, update player scores, and give 10 points bonus to winning team
                matches.Last().OnMatchEnded(10);
            }

            // get player with highest totalScore in all matches
            Player max = players.Aggregate((l, r) => l.Value.TotalScore > r.Value.TotalScore ? l : r).Value;
            
            // print MVP
            Console.WriteLine("MVP: \n" + max.ToString());
            Console.Read();
        }
    }
}
