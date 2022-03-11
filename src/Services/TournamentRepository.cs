using System;
using System.Collections.Generic;
using System.Linq;
using Tournaments.DataAccess;
using Tournaments.Model;

namespace Tournaments.Services
{
    public class TournamentRepository
    {
       
        private static TournamentContext _context = new();

        public string CreateTournament(TournamentToCreate tournamentToCreate)
        {
            var id = Guid.NewGuid().ToString();
            var tournament = new Tournament(id,tournamentToCreate.Name);
            _context.Tournaments.Add(tournament);
            return id;
        }

        public Tournament? GetTournament(string id)
        {
            return _context.Tournaments.FirstOrDefault(x => x.Id==id);
        }

        
    }
}