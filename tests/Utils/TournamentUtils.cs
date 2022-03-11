using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Tournaments.Model;

namespace Tournaments.Tests.Utils
{
    public static class TournamentUtils
    {
        public static async Task<Response<CreatedResponse>> CreateTournament(string tournamentName, HttpClient httpClient)
        {
            var tournament = new TournamentToCreate
            {
                Name = tournamentName
            };
            
            var client = httpClient;
            var response = await client.PostAsync("/api/tournaments",
                new StringContent(JsonSerializer.Serialize(tournament), Encoding.UTF8, "application/json"));

            CreatedResponse content = null;
            if (response.IsSuccessStatusCode)
            {
                content = JsonSerializer.Deserialize<CreatedResponse>(await response.Content.ReadAsStringAsync());
            }
            return new Response<CreatedResponse>(response.StatusCode, content);
        }
        
        public static async Task<Response<Tournament>> GetTournament(string tournamentId, HttpClient httpClient)

        {
            var client = httpClient;
            var response = await client.GetAsync($"/api/tournaments/{tournamentId}");

            Tournament tournament = null;
            if (response.IsSuccessStatusCode)
            {
                tournament =
                    JsonSerializer.Deserialize<Model.Tournament>(await response.Content.ReadAsStringAsync());
            }

            return new Response<Tournament>(response.StatusCode, tournament);
        }

        public static async Task<Response<Tournament>> AddEquipesToTournament(string idTournament, ParticipantsToAdd participants, HttpClient httpClient)
        
        {
            var client =httpClient;
            HttpContent content = new StringContent(JsonSerializer.Serialize(participants), Encoding.UTF8,"application/json");
     
            var response = await client.PutAsync($"/api/tournaments/{idTournament}", content);
            Tournament tournament = null;
            if (response.IsSuccessStatusCode)
            {
                tournament =
                    JsonSerializer.Deserialize<Model.Tournament>(await response.Content.ReadAsStringAsync());
            }

            return new Response<Tournament>(response.StatusCode, tournament);
        }


        public static async Task<Response<Tournament>> RemoveEquipeFromTournament(string idTournament, string equipe, HttpClient httpClient)
        
        {
            var client =httpClient;
            HttpContent content = new StringContent(JsonSerializer.Serialize(equipe), Encoding.UTF8, "application/json");

            var response = await client.PatchAsync($"/api/tournaments/{idTournament}", content);
            Tournament tournament = null;
            if (response.IsSuccessStatusCode)
            {
                tournament =
                    JsonSerializer.Deserialize<Model.Tournament>(await response.Content.ReadAsStringAsync());
            }

            return new Response<Tournament>(response.StatusCode, tournament);
        }

    }
}