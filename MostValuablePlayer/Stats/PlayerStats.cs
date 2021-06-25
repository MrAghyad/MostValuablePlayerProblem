using MostValuablePlayer.Core;
using MostValuablePlayer.PlayerPositions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.Stats
{
    abstract class PlayerStats
    {
        Team team;
        IPlayerPosition position;
        Match match;
        int score;
        PlayerPositionFactory playerPositionFactory;

    }
}
