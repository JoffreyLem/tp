using System.Collections.Generic;

namespace Tournaments.Model
{
    public class Equipes
    {
        public Equipes(string name, List<Participants> participants)
        {
            Name = name;
            Participants = participants;
        }

        public string Name { get; set; }
        private List<Participants> Participants { get; set; }
    }
}