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
        private readonly ITeamReadModelGateway _teamQueries;
        private readonly ITournamentReadModelGateway _queries;
        private readonly ITournamentRegistrationService _service;

        public TournamentController(ITournamentReadModelGateway queries, ITeamReadModelGateway teamQueries, ITournamentRegistrationService service)
        {
            _queries = queries;
            _service = service;
            _teamQueries = teamQueries;
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

        [HttpGet]
        public IActionResult Register(int id) 
        {
            var model = new RegisterTeamVm
            {
                TournamentId = id,
                Teams = _teamQueries.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterTeamVm model)
        {
            if (model.SelectedTeamId == 0)
            {   TempData["Error"] = "Please select a team.";
				model.Teams = _teamQueries.GetAll();
				return View(model);
            }

            var result = _service.RegisterTeam(
                model.TournamentId,
                model.SelectedTeamId
            );

            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                model.Teams = _teamQueries.GetAll();
                return View(model);
            }

            if (result.IsWaitlisted)
            {
                TempData["Info"] = "Team is waitlisted due to tournament capacity.";
            }
            else
            {

                TempData["Success"] = "Team registered successfully!";
            }
            return RedirectToAction("Details", new { id = model.TournamentId });
        }
    }
}