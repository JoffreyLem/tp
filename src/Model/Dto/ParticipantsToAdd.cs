using System.Collections.Generic;

namespace Tournaments.Model
{
    public class ParticipantsToAdd
    {
        public ParticipantsToAdd()
        {
            Equipes = new List<Equipes>();
        }

        public List<Equipes> Equipes { get; set; }
    }
}