using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tournaments.Model
{
    public class Tournament
    {
        public Tournament()
        {
            Equipes = new List<Equipes>();
        }

        [Key]
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("participants")]
        public List<Equipes> Equipes { get; set; }
    }
}