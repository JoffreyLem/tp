using System.Data.Common;
using Effort;
using Effort.Provider;
using Microsoft.EntityFrameworkCore;
using Tournaments.Model;

namespace Tournaments.DataAccess
{
    public class TournamentContext : DbContext
    {


        public TournamentContext()

        {

        }
        public TournamentContext(DbContextOptions<TournamentContext> options)
            : base(options)
        {

        }

    

        public DbSet<Equipes> Equipes { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Tournament;Trusted_Connection=True;");
            }
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}