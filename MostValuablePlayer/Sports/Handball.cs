using MostValuablePlayer.Core;
using MostValuablePlayer.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.Sports
{
    /// <summary>
    /// A class that represents handball sport that implements ISport
    /// </summary>
    class Handball : ISport
    {
        /// <summary>
        /// Creates PlayerStats of a match
        /// </summary>
        /// <param name="match"></param>
        /// <param name="rawPlayerInfo"></param>
        /// <returns>HandballStats of a match</returns>
        public PlayerStats GetStats(Match match, RawInfo rawPlayerInfo)
        {
            return new HandballStats(match, rawPlayerInfo);
        }
    }
}
