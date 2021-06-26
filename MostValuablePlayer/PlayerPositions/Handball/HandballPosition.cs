using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.PlayerPositions.Handball
{
    /// <summary>
    /// Abstract class that represents handball positions
    /// </summary>
    abstract class HandballPosition : IPlayerPosition
    {
        /// <summary>
        /// Calculates player score in match based on rating points defined per handball position
        /// </summary>
        /// <param name="stats">detailed match scores statistics</param>
        /// <returns>total score calculated using ratings of handball position</returns>
        public abstract int CalculateScore(Dictionary<string, int> stats);
    }
}
