using MostValuablePlayer.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.Core
{
    /// <summary>
    /// Class that represents sports player
    /// </summary>
    class Player
    {
        string name;
        string nickName;
        List<PlayerStats> playerMatchesStats;
        int totalScore;

        public int TotalScore { get => totalScore; }

        public Player()
        {
            playerMatchesStats = new List<PlayerStats>();
        }

        public Player(string name, string nickName) : this()
        {
            
            this.name = name;
            this.nickName = nickName;
        }

        /// <summary>
        /// Adds a given playerStats to player's collection of overtime PlayerStats
        /// </summary>
        /// <param name="playerStats"></param>
        public void AddPlayerStats(PlayerStats playerStats)
        {
            playerMatchesStats.Add(playerStats);
        }

        /// <summary>
        /// Adds bonus to player's score in a match when won
        /// </summary>
        /// <param name="match"></param>
        /// <param name="bonus"></param>
        public void OnTeamWonMatchAddBonus(Match match, int bonus)
        {
            PlayerStats stats = GetStatsOfMatch(match);
            stats.OnTeamWon(bonus);
        }

        /// <summary>
        /// Returns playerStats in a given match
        /// </summary>
        /// <param name="match"></param>
        /// <returns>playerStats in a match</returns>
        private PlayerStats GetStatsOfMatch(Match match)
        {
            return playerMatchesStats.Find(ps => ps.Match == match);
        }

        /// <summary>
        /// Updates totalScore of player by adding score of player in a match
        /// </summary>
        /// <param name="match"></param>
        public void UpdateTotalScore(Match match)
        {
            PlayerStats stats = GetStatsOfMatch(match);
            totalScore += stats.Score;
        }

        public override string ToString()
        {
            string tostring = "Name: " + name;
            tostring += "\nNickName: " + nickName;
            tostring += "\nTotalScore: " + totalScore;

            return tostring;

        }
    }
}
