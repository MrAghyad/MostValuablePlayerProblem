using MostValuablePlayer.Core;
using MostValuablePlayer.PlayerPositions.Basketball;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MostValuablePlayer.Stats
{
    /// <summary>
    /// Types of Basketball Scores
    /// </summary>
    public enum BasketballScoreStats
    {
        ScoredPoint, Rebound, Assist
    }
    /// <summary>
    /// A class that represents player statistics (PlayerStats) for basketball sport
    /// </summary>
    class BasketballStats : PlayerStats
    {

        public BasketballStats(Match match, RawInfo rawPlayerInfo)
        {
            Initialize(match, rawPlayerInfo);
        }

        /// <summary>
        /// Sets player position based on a given position name
        /// </summary>
        /// <param name="positionName"></param>
        public override void SetPosition(string positionName)
        {
            if(positionName == "G")
            {
                position = new Guard();
            }
            else if (positionName == "F")
            {
                position = new Forward();
            }
            else if (positionName == "C")
            {
                position = new Center();
            }
        }

        /// <summary>
        /// Sets player match scores based on BasketballScoresStats
        /// </summary>
        /// <param name="statsInfo"></param>
        protected override void SetStatsScores(IEnumerable<string> statsInfo)
        {
            statsScores = new Dictionary<string, int>();
            statsScores[BasketballScoreStats.ScoredPoint.ToString()] = int.Parse(statsInfo.ElementAt(0));
            statsScores[BasketballScoreStats.Rebound.ToString()] = int.Parse(statsInfo.ElementAt(1));
            statsScores[BasketballScoreStats.Assist.ToString()] = int.Parse(statsInfo.ElementAt(2));

            // update player scores
            UpdateScore();

            // update team scores
            match.UpdateTeamScore(teamName, statsScores[BasketballScoreStats.ScoredPoint.ToString()]);
        }

    }
}
