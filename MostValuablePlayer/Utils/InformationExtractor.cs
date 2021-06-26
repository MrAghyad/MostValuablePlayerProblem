using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MostValuablePlayer.Core;
using System.Linq;

namespace MostValuablePlayer.Utils
{
    /// <summary>
    /// A helper class that is used to extract information
    /// </summary>
    static class InformationExtractor
    {
        /// <summary>
        /// Extracts lines from a file
        /// </summary>
        /// <param name="path">string path to file</param>
        /// <returns>IEnumberable of lines as strings</returns>
        public static IEnumerable<string> ExtractLinesFromFile(string path)
        {
            string[] lines = null;
            try
            {
                lines = File.ReadAllLines(path);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return lines;
        }

        /// <summary>
        /// Exctracts information from string (match file line)
        /// </summary>
        /// <param name="str">string that represents match file line</param>
        /// <returns>RawInfo instance</returns>
        public static RawInfo ExtractInformationFromString(string str)
        {
            List<string> splitted_Info = str.Split(";").ToList();
            RawInfo rawPlayerInfo = new RawInfo
            {
                PlayerName = splitted_Info[0],
                PlayerNickName = splitted_Info[1],
                PlayerNumber = int.Parse(splitted_Info[2]),
                TeamName = splitted_Info[3],
                PositionName = splitted_Info[4],
                PlayerStatsInfo = splitted_Info.GetRange(5, splitted_Info.Count - 5)
            };

            return rawPlayerInfo;
        }

    }
}
