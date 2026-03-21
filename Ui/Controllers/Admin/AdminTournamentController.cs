using Bowling_Tournament_Registration_System.Domain.Services;
using Bowling_Tournament_Registration_System.Ui.Queries;
using Bowling_Tournament_Registration_System.Ui.ReadModels;
using Bowling_Tournament_Registration_System.Ui.ViewModels;
using Bowling_Tournament_Registration_System.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Bowling_Tournament_Registration_System.Ui.Admin.Controllers
{
    public class AdminTournamentController : Controller
    {
        private readonly ITournamentReadModelGateway _queries;
        private readonly ITournamentManagementService _service;

        public AdminTournamentController(ITournamentReadModelGateway queries, ITournamentManagementService service)
        {
            _queries = queries;
            _service = service;
        }

        public IActionResult Index()
        {
            var tournaments = _queries.GetAll();
            return View(tournaments);
        }

        //public IActionResult Details(int id)
        //{
        //    var tournament = _queries.GetById(id);

        //    if (tournament == null)
        //        return NotFound();

        //    return View(tournament);
        //}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTournamentVm model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var tournamentRequest = new TournamentRequest
            {
                Name = model.Name,
                TournamentDate = model.Date,
                Location = model.Location,
                Capacity = model.Capacity
            };
			var id = _service.CreateTournament(tournamentRequest);

			if (id == 0)
            {
                ModelState.AddModelError("", "Failed to create tournament");
                return View(model);
            }

            TempData["SuccessMessage"] = "Tournament created successfully!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tournament = _queries.GetById(id);

            if (tournament == null)
                return NotFound();

            var model = new EditTournamentVm
            {
                Id = tournament.Id,
                Name = tournament.Name,
                Date = tournament.Date,
                Location = tournament.Location,
                Capacity = tournament.Capacity
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
                Capacity = model.Capacity
            };
			var result = _service.UpdateTournament(model.Id, tournamentRequest);

			if (!result)
            {
                ModelState.AddModelError("", "Error");
                return View(model);
            }
                
            return RedirectToAction("Details" ,"Tournament", new { id = model.Id });
        }
    }
}