using MostValuablePlayer.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.PlayerPositions.Basketball
{
    /// <summary>
    /// A class representing Guard BasketballPosition
    /// </summary>
    class Guard : BasketballPosition
    {
        /// <summary>
        /// Calculates player score in match based on rating points defined for Guard
        /// </summary>
        /// <param name="stats">detailed match scores statistics</param>
        /// <returns>total score calculated using ratings of Guard position</returns>
        public override int CalculateScore(Dictionary<string, int> stats)
        {
            return (stats[BasketballScoreStats.ScoredPoint.ToString()] * 2)
                + (stats[BasketballScoreStats.Rebound.ToString()] * 3)
                + (stats[BasketballScoreStats.Assist.ToString()] * 1);
        }
        
    }
}
