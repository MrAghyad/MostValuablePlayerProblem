using MostValuablePlayer.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.PlayerPositions
{
    /// <summary>
    /// Interface of player positions in sports
    /// </summary>
    interface IPlayerPosition
    {
        /// <summary>
        /// Calculates player score in match based on rating points defined per sport
        /// </summary>
        /// <param name="stats">detailed match scores statistics</param>
        /// <returns>total score calculated using ratings of sport's position</returns>
        int CalculateScore(Dictionary<string, int> stats);
    }
}
