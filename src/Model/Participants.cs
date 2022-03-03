using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tournaments.Model
{
    public class Participants
    {
        public Participants()
        {
        }

        public Participants( string name, int elo =1)
        {
            Id = Guid.NewGuid().ToString("N");
            Name = name;
            Elo = elo;
        }

        [Key]
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        public int Elo { get; set; } 
    }
}