using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.Core
{
    /// <summary>
    /// Raw information from match file 
    /// </summary>
    class RawInfo
    {
        string playerName;
        string playerNickName;
        int playerNumber;
        string teamName;
        string positionName;
        IEnumerable<string> playerStatsInfo;

        public string PlayerName { get => playerName; set => playerName = value; }
        public string PlayerNickName { get => playerNickName; set => playerNickName = value; }
        public int PlayerNumber { get => playerNumber; set => playerNumber = value; }
        public string TeamName { get => teamName; set => teamName = value; }
        public string PositionName { get => positionName; set => positionName = value; }
        public IEnumerable<string> PlayerStatsInfo { get => playerStatsInfo; set => playerStatsInfo = value; }
    }
}
