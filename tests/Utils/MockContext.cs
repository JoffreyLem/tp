using System.Data.Common;
using System.Data.Entity;
using Effort;
using Tournaments.Model;

namespace Tournaments.Tests.Utils
{
    public class MockContext : DbContext
    {
        public MockContext(DbConnection connection) : base(connection, false)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Equipes> Equipes { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Participants> Participants { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Tournament> Tournaments { get; set; }


        public MockContext GetContext()
        {
            var connection = DbConnectionFactory.CreateTransient();
            return new MockContext(connection);
        }
    }
}