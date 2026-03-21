using Bowling_Tournament_Registration_System.Domain.Services;
using Bowling_Tournament_Registration_System.Ui.Queries;
using Bowling_Tournament_Registration_System.Ui.ReadModels;
using Bowling_Tournament_Registration_System.Ui.ViewModels;
using Bowling_Tournament_Registration_System.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Bowling_Tournament_Registration_System.Ui.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentReadModelGateway _queries;
        private readonly ITournamentManagementService _service;

        public TournamentController(ITournamentReadModelGateway queries, ITournamentManagementService service)
        {
            _queries = queries;
            _service = service;
        }

        public IActionResult Index()
        {
            var tournaments = _queries.GetAll();
            return View(tournaments);
        }

        public IActionResult Details(int id)
        {
            var tournament = _queries.GetById(id);

            if (tournament == null)
                return NotFound();

            return View(tournament);
        }
    }
}