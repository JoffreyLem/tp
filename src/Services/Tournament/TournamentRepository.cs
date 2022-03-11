using System;
using System.Collections.Generic;
using System.Linq;
using Tournaments.DataAccess;
using Tournaments.Model;
using Tournaments.Services.Tournament;

namespace Tournaments.Services
{
    public class TournamentRepository : ITournamentRepository
    {
       
        private  TournamentContext _context;

        public TournamentRepository(TournamentContext context)
        {
            _context = context;
        }

        public string CreateTournament(TournamentToCreate tournamentToCreate)
        {
            var id = Guid.NewGuid().ToString();
            var tournament = new Model.Tournament(id,tournamentToCreate.Name);
            _context.Tournaments.Add(tournament);
            _context.SaveChanges();
            return id;
        }

        public Model.Tournament? GetTournament(string id)
        {
            var data = _context.Tournaments.FirstOrDefault(x => x.Id == id);
            if (data.Equipes is null)
            {
                data.Equipes = new List<Equipes>();
            }

            return data;
        }

        public void UpdateTournament(Model.Tournament tournament)
        {
            var tournamentdata = _context.Tournaments.Find(tournament.Id);
            tournamentdata = tournament;
            _context.SaveChanges();
        }
    }
}