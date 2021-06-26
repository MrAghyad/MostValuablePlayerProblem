using MostValuablePlayer.Core;
using MostValuablePlayer.PlayerPositions.Handball;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MostValuablePlayer.Stats
{
    /// <summary>
    /// Types of Handball Scores
    /// </summary>
    public enum HandballScoreStats
    {
        InitialRatingPoints, GoalMade, GoalReceived
    }

    /// <summary>
    /// A class that represents player statistics (PlayerStats) for handball sport
    /// </summary>
    class HandballStats : PlayerStats
    {

        public HandballStats(Match match, RawInfo rawPlayerInfo)
        {
            Initialize(match, rawPlayerInfo);
        }

        /// <summary>
        /// Sets player position based on a given position name
        /// </summary>
        /// <param name="positionName"></param>
        public override void SetPosition(string positionName)
        {
            if (positionName == "G")
            {
                position = new Goalkeeper();
            }
            else if (positionName == "F")
            {
                position = new FieldPlayer();
            }
        }

        /// <summary>
        /// Sets player match scores based on HandballScoresStats
        /// </summary>
        /// <param name="statsInfo"></param>
        protected override void SetStatsScores(IEnumerable<string> statsInfo)
        {
            this.statsScores = new Dictionary<string, int>();
            statsScores[HandballScoreStats.InitialRatingPoints.ToString()] = 1;
            statsScores[HandballScoreStats.GoalMade.ToString()] = int.Parse(statsInfo.ElementAt(0));
            statsScores[HandballScoreStats.GoalReceived.ToString()] = int.Parse(statsInfo.ElementAt(1));

            // update player scores
            UpdateScore();

            // update team scores
            match.UpdateTeamScore(teamName, statsScores[HandballScoreStats.GoalMade.ToString()]);
        }
    }
}
