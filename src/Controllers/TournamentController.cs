using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Tournaments.Model;
using Tournaments.Services;

namespace Tournaments.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class TournamentController: ControllerBase
    {
        private readonly TournamentRepository _tournamentRepository;

        public TournamentController(TournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        [HttpPost]
        public IActionResult CreateTournament([FromBody] TournamentToCreate tournament)
        {
            var id = _tournamentRepository.CreateTournament(tournament);
            return CreatedAtAction(nameof(GetTournamentById), new { id }, new CreatedResponse(id));
        }

        [HttpGet("{id}")]
        public Tournament GetTournamentById(string id)
        {
            return _tournamentRepository.GetTournament(id);
        }

        [HttpPut("{id}")]
        public IActionResult AddEquipesToTornament(string id, [FromBody] ParticipantsToAdd participants)
        {
          
            var tournament = _tournamentRepository.GetTournament(id);
            if (tournament == null)
            {
                return NotFound();
            }
            tournament.Equipes.AddRange(participants.Equipes);
            return Content(JsonSerializer.Serialize(tournament));

        }

        [HttpPut("/removeEquipe/{id}")]
        public IActionResult RemoveEquipeFromTournament(string id, [FromQuery] string equipe)
        {

            var tournament = _tournamentRepository.GetTournament(id);
            if (tournament == null)
            {
                return NotFound();
            }

            var selected = tournament.Equipes.Where(x => x.Name == equipe).FirstOrDefault();
            if (selected != null)
            {
                tournament.Equipes.Remove(selected);
            }
            return Content(JsonSerializer.Serialize(tournament));

        }
    }
}