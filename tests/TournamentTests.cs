using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Tournaments.Model;
using Tournaments.Tests.Utils;
using Xunit;
using Tournament = Tournaments.Model.Tournament;

namespace Tournaments.Tests
{
    public class TournamentTests : IClassFixture<ClientUtils>
    {
        private ClientUtils _clientUtils;
        private HttpClient _client;
        public TournamentTests(ClientUtils clientUtils)
        {
            _clientUtils = clientUtils;
            _client = _clientUtils.Client;
        }

        [Fact]
        public async Task Create_Tournament_Should_Return_Valid_Id()
        {
            var response = await TournamentUtils.CreateTournament("Unreal tournament",_client);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Content?.Id);
        }

      

        [Fact]
        public async Task CreatedTournament_Should_EnableToRetrieveTournamentAfterwards()
        {
            var tournamentName = "New Tournament";

            var response = await TournamentUtils.CreateTournament(tournamentName,_client);
            var tournamentResponse = await TournamentUtils.GetTournament(response.Content.Id,_client);

            Assert.Equal(HttpStatusCode.OK, tournamentResponse.StatusCode);
            Assert.NotNull(tournamentResponse.Content);

            var tournament = tournamentResponse.Content;
            Assert.NotNull(tournament.Id);
            Assert.Equal(tournamentName, tournament.Name);
        }

        [Fact]
        public async Task AddEquipes_should_RetrieveEquipes()
        {
            var tournamentName = "New Tournament";

            List<Participants> participants = new List<Participants>()
            {
                new Participants( "test1",1),
                new Participants( "test2",2),
                new Participants( "test3",3)
            };
            List<Participants> participants2 = new List<Participants>()
            {
                new Participants( "test1",1),
                new Participants( "test2",2),
                new Participants( "test3",3)
            };

            var equipe = new Equipes("Equipe1",participants);
            var equipe2 = new Equipes("Equipe2", participants2);
            var data = new ParticipantsToAdd();
            data.Equipes.Add(equipe);
            data.Equipes.Add(equipe2);

            var response = await TournamentUtils.CreateTournament(tournamentName,_client);
            var tournamentResponse = await TournamentUtils.GetTournament(response.Content.Id, _client);

            var addParticipants = await TournamentUtils.AddEquipesToTournament(response.Content.Id, data, _client);
             tournamentResponse = await TournamentUtils.GetTournament(response.Content.Id, _client);
            Assert.Equal(HttpStatusCode.OK, tournamentResponse.StatusCode);
            Assert.NotNull(tournamentResponse.Content);
            var tournament = tournamentResponse.Content;
            Assert.NotNull(tournament.Equipes);
            Assert.Equal(2, tournament.Equipes.Count);
        }

        [Fact]
        public async Task RemoveEquipe_should_Retrieve0Equipes()
        {
            var tournamentName = "New Tournament";

            List<Participants> participants = new List<Participants>()
            {
                new Participants( "test1",1),
                new Participants( "test2",2),
                new Participants( "test3",3)
            };
        

            var equipe = new Equipes("Equipe1", participants);
         
            var data = new ParticipantsToAdd();
            data.Equipes.Add(equipe);
   

            var response = await TournamentUtils.CreateTournament(tournamentName, _client);
            var tournamentResponse = await TournamentUtils.GetTournament(response.Content.Id, _client);

            var addParticipants = await TournamentUtils.AddEquipesToTournament(response.Content.Id, data, _client);
            var tournament = addParticipants.Content;
            Assert.Equal(HttpStatusCode.OK, addParticipants.StatusCode);
            Assert.NotNull(tournamentResponse.Content);
         
            Assert.NotNull(tournament.Equipes);
            Assert.Equal(1, tournament.Equipes.Count);


            var removeParticipants =
                await TournamentUtils.RemoveEquipeFromTournament(response.Content.Id, "Equipe1", _client);
            tournament = removeParticipants.Content;
            Assert.Equal(HttpStatusCode.OK, addParticipants.StatusCode);
            Assert.NotNull(tournamentResponse.Content);

            Assert.NotNull(tournament.Equipes);
            Assert.Equal(0, tournament.Equipes.Count);
        }
    }
}