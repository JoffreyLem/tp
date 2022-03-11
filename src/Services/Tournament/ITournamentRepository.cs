using Tournaments.Model;

namespace Tournaments.Services.Tournament
{
    public interface ITournamentRepository
    {
        public string CreateTournament(TournamentToCreate tournamentToCreate);

        public Model.Tournament? GetTournament(string id);

        public void UpdateTournament(Model.Tournament tournament);
      
    }
}