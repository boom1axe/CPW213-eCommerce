using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Data
{
    /// <summary>
    /// DB Helper class for VideoGames
    /// </summary>
    public static class VideoGameDb
    {
        /// <summary>
        /// Addes a VideoGame to eh data store
        /// </summary>
        /// <param name="g">The game to be added</param>
        /// <param name="context">The DB context to use</param>
        /// <returns></returns>
        public static VideoGame Add(VideoGame g, GameContext context)
        {
            context.Add(g);
            context.SaveChanges();
            return g;
        }
    }
}
