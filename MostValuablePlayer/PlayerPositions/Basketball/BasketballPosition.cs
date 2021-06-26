using MostValuablePlayer.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.PlayerPositions.Basketball
{
    /// <summary>
    /// Abstract class that represents basketball positions
    /// </summary>
    abstract class BasketballPosition : IPlayerPosition
    {
        /// <summary>
        /// Calculates player score in match based on rating points defined per basketball position
        /// </summary>
        /// <param name="stats">detailed match scores statistics</param>
        /// <returns>total score calculated using ratings of basketball position</returns>
        public abstract int CalculateScore(Dictionary<string, int> stats);
        
    }
}
