using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournaments.Model
{
    public class Equipes
    {

        public Equipes()
        {
          
        }
        public Equipes(string name, List<Participants> participants)
        {
            Name = name;
            Participants = participants;
        }

        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        private List<Participants> Participants { get; set; }
        
        [NotMapped]
        [ForeignKey("TournamentId")]
        public virtual Tournament TournamentId { get; set; }
    }
}