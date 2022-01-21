using System.Collections.Generic;

namespace Archer
{
    internal class AssetsPath
    {
        public static readonly Dictionary<Assets, string> Path = new Dictionary<Assets, string>
        {
            { Assets.StartLevel, "Data/Locations/StartLocation" },
            { Assets.Player, "Prefabs/Player" },
            { Assets.Enemy, "Data/Enemies/CommonEnemies" },
            { Assets.Coin, "Prefabs/Coin" },
        };
    }
}