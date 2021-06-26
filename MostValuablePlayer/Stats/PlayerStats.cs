using MostValuablePlayer.Core;
using MostValuablePlayer.PlayerPositions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.Stats
{
    /// <summary>
    /// Abstract class representing Player's match statistics
    /// </summary>
    abstract class PlayerStats
    {
        protected string teamName;                      
        protected int playerNumber;                    
        protected IPlayerPosition position;             // player position in the match based on sport
        protected Match match;                          // current match
        private int score;                              // total score of the player in the current match
        protected Dictionary<string, int> statsScores;  // match detailed scores of player (depends on the type of sport)
        private bool won;

        public Match Match { get => match;}
        public int Score { get => score;}

        /// <summary>
        /// Sets player match scores based on match sport implementer
        /// </summary>
        /// <param name="stats"></param>
        protected abstract void SetStatsScores(IEnumerable<string> stats);
        
        /// <summary>
        /// Sets player position based on a given position name
        /// </summary>
        /// <param name="positionName"></param>
        public abstract void SetPosition(string positionName);
        
        /// <summary>
        /// Updates player's score of the match based on match detailed scores 
        /// </summary>
        public void UpdateScore()
        {
            score = position.CalculateScore(statsScores);
        }
        
        /// <summary>
        /// Adds bonus to player's score of the current match
        /// </summary>
        /// <param name="bonus">int value of bonus</param>
        public void OnTeamWon(int bonus)
        {
            won = true;
            score += bonus;
        }

        /// <summary>
        /// Initializes PlayerStats
        /// </summary>
        /// <param name="match"></param>
        /// <param name="rawPlayerInfo"></param>
        protected virtual void Initialize(Match match, RawInfo rawPlayerInfo)
        {
            this.match = match;
            this.teamName = rawPlayerInfo.TeamName;
            this.playerNumber = rawPlayerInfo.PlayerNumber;

            SetPosition(rawPlayerInfo.PositionName);
            SetStatsScores(rawPlayerInfo.PlayerStatsInfo);
        }
    }
}
