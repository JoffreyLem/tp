using Microsoft.EntityFrameworkCore;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Tournament;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}