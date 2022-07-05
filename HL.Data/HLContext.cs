using HL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Data
{
    public class HLContext : DbContext
    {
        public HLContext(DbContextOptions<HLContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerGame> PlayerGames { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<StepAnswer> StepAnswers { get; set; }
    }
}
