using Bowling_Tournament_Registration_System.Domain.Dtos;
using Bowling_Tournament_Registration_System.Domain.Services;
using Bowling_Tournament_Registration_System.Ui.Queries;
using Bowling_Tournament_Registration_System.Ui.ReadModels;
using Bowling_Tournament_Registration_System.Ui.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bowling_Tournament_Registration_System.Ui.Admin.Controllers
{
	[Authorize]
	public class AdminTournamentController : Controller
    {
        private readonly ITeamReadModelGateway _teamQueries;
        private readonly ITournamentReadModelGateway _queries;
        private readonly ITournamentManagementService _service;
        private readonly ITournamentRegistrationService _RegService;
        private readonly IDivisionReadModelGateway _divisionRead;


        public AdminTournamentController(ITournamentReadModelGateway queries, ITournamentManagementService service, ITeamReadModelGateway teamQueries, IDivisionReadModelGateway divisionRead)
        {
            _queries = queries;
            _service = service;
            _teamQueries = teamQueries;
            _divisionRead = divisionRead;
        }

        public IActionResult Index()
        {
            var tournaments = _queries.GetAll();
            return View(tournaments);
        }

 

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateTournamentVm
            {
				DivisionCapacities = _divisionRead.GetDivisionOptions()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateTournamentVm model)
        {
            if (!ModelState.IsValid)
            {
		
				return View(model);
			}

            var tournamentRequest = new TournamentRequest
            {
                Name = model.Name,
                TournamentDate = model.Date,
                Location = model.Location,
                Capacity = model.Capacity,
                DivisionCapacities = model.DivisionCapacities.Select(d => new DivisionCapacityRequest
                {
                    DivisionId = d.Id,
                    Capacity = d.Capacity
                }).ToList()
            };
            var result = _service.CreateTournament(tournamentRequest);

			if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return View(model);
            }

            TempData["Success"] = "Tournament created successfully!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tournament = _queries.GetById(id);

            var divisions = _divisionRead.GetDivisionCapacities(id);
			

            if (tournament == null)
                return NotFound();

            var model = new EditTournamentVm
            {
                Id = tournament.Id,
                Name = tournament.Name,
                Date = tournament.Date,
                Location = tournament.Location,
                Capacity = tournament.Capacity,

                DivisionCapacities = divisions.Select(d => new DivisionOption
                {
                    Id = d.DivisionId,
                    Name = d.DivisionName, 
                    Capacity = d.Capacity
                }).ToList()
            };


            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditTournamentVm model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var tournamentRequest = new TournamentRequest
            {
                Name = model.Name,
                TournamentDate = model.Date,
                Location = model.Location,
                Capacity = model.Capacity,

                DivisionCapacities = model.DivisionCapacities.Select(dc => new DivisionCapacityRequest
                {
                    DivisionId = dc.Id,
                    Capacity = dc.Capacity
                }).ToList()
            };
            var result = _service.UpdateTournament(model.Id, tournamentRequest);

            if (!result.Success)
            {
				TempData["Error"] = result.ErrorMessage;
				return View(model);
            }

			TempData["Success"] = "Tournament updated successfully!";
			return RedirectToAction("Details" ,"Tournament", new { id = model.Id });
        }
    }
}