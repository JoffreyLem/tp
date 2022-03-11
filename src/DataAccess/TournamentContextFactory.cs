using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Tournaments.DataAccess
{
    public class TournamentContextFactory : IDesignTimeDbContextFactory<TournamentContext>
    {
        public TournamentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TournamentContext>();
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Tournament;Trusted_Connection=True;");

            return new TournamentContext(optionsBuilder.Options);

        }
    }
}