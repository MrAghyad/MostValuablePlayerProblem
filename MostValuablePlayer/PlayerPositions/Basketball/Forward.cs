using MostValuablePlayer.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.PlayerPositions.Basketball
{
    /// <summary>
    /// A class representing Forward BasketballPosition
    /// </summary>
    class Forward : BasketballPosition
    {
        /// <summary>
        /// Calculates player score in match based on rating points defined for Forward
        /// </summary>
        /// <param name="stats">detailed match scores statistics</param>
        /// <returns>total score calculated using ratings of Forward position</returns>
        public override int CalculateScore(Dictionary<string, int> stats)
        {
            return (stats[BasketballScoreStats.ScoredPoint.ToString()] * 2)
                + (stats[BasketballScoreStats.Rebound.ToString()] * 2)
                + (stats[BasketballScoreStats.Assist.ToString()] * 2);
        }
    }
}
