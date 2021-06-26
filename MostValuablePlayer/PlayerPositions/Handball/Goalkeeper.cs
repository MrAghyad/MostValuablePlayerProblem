using MostValuablePlayer.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.PlayerPositions.Handball
{
    /// <summary>
    /// A class representing Goalkeeper handball position
    /// </summary>
    class Goalkeeper : HandballPosition
    {
        /// <summary>
        /// Calculates player score in match based on rating points defined for GoalKeeper
        /// </summary>
        /// <param name="stats">detailed match scores statistics</param>
        /// <returns>total score calculated using ratings of GoalKeeper position</returns>
        public override int CalculateScore(Dictionary<string, int> stats)
        {
            
            return (stats[HandballScoreStats.InitialRatingPoints.ToString()] * 50)
                + (stats[HandballScoreStats.GoalMade.ToString()] * 5)
                + (stats[HandballScoreStats.GoalReceived.ToString()] * -2);
            
        }
    }
}
