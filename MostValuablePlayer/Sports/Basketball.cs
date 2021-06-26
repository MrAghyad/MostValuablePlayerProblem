using MostValuablePlayer.Core;
using MostValuablePlayer.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.Sports
{
    /// <summary>
    /// A class that represents basketball sport that implements ISport
    /// </summary>
    class Basketball : ISport
    {
        /// <summary>
        /// Creates PlayerStats of a match
        /// </summary>
        /// <param name="match"></param>
        /// <param name="rawPlayerInfo"></param>
        /// <returns>BasketballStats of a match</returns>
        public PlayerStats GetStats(Match match, RawInfo rawPlayerInfo)
        {
            return new BasketballStats(match, rawPlayerInfo);
        }
    }
}
