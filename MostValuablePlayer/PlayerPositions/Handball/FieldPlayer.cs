using MostValuablePlayer.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.PlayerPositions.Handball
{
    /// <summary>
    /// A class representing FieldPlayer handball position
    /// </summary>
    class FieldPlayer : HandballPosition
    {
        /// <summary>
        /// Calculates player score in match based on rating points defined for FieldPlayer
        /// </summary>
        /// <param name="stats">detailed match scores statistics</param>
        /// <returns>total score calculated using ratings of FieldPlayer position</returns>
        public override int CalculateScore(Dictionary<string, int> stats)
        {

            return (stats[HandballScoreStats.InitialRatingPoints.ToString()] * 20)
                + (stats[HandballScoreStats.GoalMade.ToString()] * 1)
                + (stats[HandballScoreStats.GoalReceived.ToString()] * -1);

        }
    }
}
