using MostValuablePlayer.Core;
using MostValuablePlayer.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.Sports
{
    interface ISport
    {
        /// <summary>
        /// Creates PlayerStats of a match
        /// </summary>
        /// <param name="match"></param>
        /// <param name="rawPlayerInfo"></param>
        /// <returns>PlayerStats of a match</returns>
        PlayerStats GetStats(Match match, RawInfo rawPlayerInfo);
    }
}
