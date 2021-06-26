using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MostValuablePlayer.Sports;
using MostValuablePlayer.Stats;
using MostValuablePlayer.Utils;

namespace MostValuablePlayer.Core
{
    /// <summary>
    /// A class representing sport Match
    /// </summary>
    class Match
    {
        ISport matchSport;
        Dictionary<string, List<Player>> teams;
        Dictionary<string, int> teamsScores;

        public ISport MatchSport { get => matchSport; }

        public Match(string sportName)
        {
            teams = new Dictionary<string, List<Player>>();
            teamsScores = new Dictionary<string, int>();
            SetSport(sportName);
        }

        /// <summary>
        /// Sets match sport using a given sportName
        /// </summary>
        /// <param name="sportName">string containing sport name</param>
        void SetSport(string sportName)
        {
            SportFactory sportFactory = new SportFactory();
            matchSport = sportFactory.GetSport(sportName);
        }

        /// <summary>
        /// Adds player to a team
        /// </summary>
        /// <param name="player"></param>
        /// <param name="rawPlayerInfo"></param>
        /// <returns>PlayerStats of the match</returns>
        public PlayerStats AddPlayerToTeam(Player player, RawInfo rawPlayerInfo)
        {
            if(teams.ContainsKey(rawPlayerInfo.TeamName) == false)
            {
                teams[rawPlayerInfo.TeamName] = new List<Player>();
            }
            teams[rawPlayerInfo.TeamName].Add(player);

            // return PlayerStats created from match and raw player info
            return matchSport.GetStats(this, rawPlayerInfo);
        }

        public void UpdateTeamScore(string teamName, int playerScore)
        {
            if (teamsScores.ContainsKey(teamName) == false)
            {
                teamsScores[teamName] = 0;
            }
            teamsScores[teamName] += playerScore;
        }

        /// <summary>
        /// When a match ends, this method is called to update player scores in the match, and gives bonus points to winning team members
        /// </summary>
        /// <param name="bonus"></param>
        public void OnMatchEnded(int bonus)
        {
            AddBonusToWinningTeam(bonus);
            UpdatePlayersTotalScores();
        }

        /// <summary>
        /// Updates player's total score by adding scores of current match
        /// </summary>
        void UpdatePlayersTotalScores()
        {
            foreach (var team in teams)
            {
                foreach (var player in team.Value)
                {
                    player.UpdateTotalScore(this);
                }
            }
        }

        /// <summary>
        /// Returns winning team's name based on teams scores
        /// </summary>
        /// <returns>name of winning team</returns>
        string GetWinningTeam()
        {
            var max = teamsScores.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            return max;
        }

        /// <summary>
        /// Adds bonus points to winning team's players
        /// </summary>
        /// <param name="bonus"></param>
        public void AddBonusToWinningTeam(int bonus)
        {
            string winningTeam = GetWinningTeam();

            foreach (var player in teams[winningTeam])
            {
                player.OnTeamWonMatchAddBonus(this, bonus);
            }
        }

    }
}
