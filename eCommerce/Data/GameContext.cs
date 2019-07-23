using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Data
{
    /// <summary>
    /// The database context class for
    /// the video game store
    /// </summary>
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {

        }

        // add a Db<T> for each enity you want to
        // keep tract of in the database
        public DbSet<VideoGame> VideoGames { get; set; }
    }
}
