using System;
using System.Collections.Generic;
using System.Text;

namespace MostValuablePlayer.Sports
{
    /// <summary>
    /// A factory that creates ISport types
    /// </summary>
    class SportFactory
    {
        /// <summary>
        /// Creates an instance of class that implements ISport using a provided sportName
        /// </summary>
        /// <param name="sportName">string containing sport name</param>
        /// <returns>ISport class instance</returns>
        public ISport GetSport(string sportName)
        {
            if(sportName.Equals("BASKETBALL", StringComparison.OrdinalIgnoreCase))
            {
                return new Basketball();
            }

            if (sportName.Equals("HANDBALL", StringComparison.OrdinalIgnoreCase))
            {
                return new Handball();
            }

            return null;
        }
    }
}
