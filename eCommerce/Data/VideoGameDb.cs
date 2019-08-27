using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
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
        public static async Task<VideoGame> AddAsync(VideoGame g, GameContext context)
        {
            await context.AddAsync(g);
            await context.SaveChangesAsync();
            return g;
        }

        public static async Task<VideoGame> UpdateGame(VideoGame g, GameContext context)
        {
            context.Update(g);
            await context.SaveChangesAsync();
            return g;
        }

        /// <summary>
        /// Retrives all games sorted by alphabetical order
        /// by title
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<List<VideoGame>> GetAllGames(GameContext context)
        {
            //LINQ Query syntax
            //List<VideoGame> games =
            //    await (from vidGame in context.VideoGames
            //           orderby vidGame.Title ascending
            //           select vidGame).ToListAsync();

            //LINQ Method Syntax
            List<VideoGame> games = await context.VideoGames
                .OrderBy(g => g.Title)
                .ToListAsync();

            return games;
        }

        public static async Task<VideoGame> GetGameById(int id, GameContext context)
        {
            VideoGame g = await (from game in context.VideoGames
                           where game.Id == id
                           select game).SingleOrDefaultAsync();

            return g;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<List<VideoGame>> SearchAsync(GameContext context, SearchCriteria criteria)
        {
            // Selects * from VideoGames
            // This does NOT query the database
            IQueryable<VideoGame> allGames =
                from g in context.VideoGames
                select g;

            if (criteria.MinPrice.HasValue)
            {
                //add to where
                //price >= crieria.minprice
                allGames = from g in allGames
                           where g.Price >= criteria.MinPrice
                           select g;
            }

            if (criteria.MaxPrice.HasValue)
            {
                allGames = from g in allGames
                           where g.Price <= criteria.MaxPrice
                           select g;
            }

            if (!string.IsNullOrWhiteSpace(criteria.Title))
            {
                allGames = from g in allGames
                           where g.Title.StartsWith(criteria.Title)
                           select g;
            }

            if (!string.IsNullOrWhiteSpace(criteria.Rating))
            {
                allGames = from g in allGames
                           where g.Rating == criteria.Rating
                           select g;
            }

            // send final query to database to return results
            // EF does not send the Query to the DB untill 
            return await allGames.ToListAsync();
        }
    }
}
