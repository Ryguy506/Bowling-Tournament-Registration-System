using Bowling_Tournament_Registration_System.Domain.Dtos;
using Bowling_Tournament_Registration_System.Domain.Services;
using Bowling_Tournament_Registration_System.Ui.Queries;
using Bowling_Tournament_Registration_System.Ui.ReadModels;
using Bowling_Tournament_Registration_System.Ui.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Bowling_Tournament_Registration_System.Ui.Controllers.Admin
{
	[Authorize]
	public class AdminTeamController : Controller
	{
		private readonly ITeamReadModelGateway _Teamqueries;
		private readonly IPlayerReadModelGateway _Playerqueries;
		private readonly ITeamManagementService _service;

		public AdminTeamController(ITeamReadModelGateway Tqueries, IPlayerReadModelGateway Pqueries  ,  ITeamManagementService service)
		{
			_service = service;
			_Teamqueries = Tqueries;
			_Playerqueries = Pqueries;
		}
		public IActionResult Index()
		{
			var teams = _Teamqueries.GetAll();
			
			return View(teams);
		}

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateTeamVm
            {
                Divisions = _Teamqueries.GetAll() 
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateTeamVm model)
        {
            if (!ModelState.IsValid)
            {
                model.Divisions = _Teamqueries.GetAll();
                return View(model);
            }

            var request = new TeamRequest
            {
                TeamName = model.TeamName,
                DivisionId = model.DivisionId
            };

            int teamId = _service.CreateTeam(request);

            if (teamId <= 0)
            {
                TempData["Error"] = "Failed to create team.";
                model.Divisions = _Teamqueries.GetAll();
                return View(model);
            }

            TempData["Success"] = "Team created successfully.";

            return RedirectToAction("Edit", new { id = teamId });
        }

        public IActionResult Edit(int id)
		{
			var model = new EditTeamVm
			{
				Team = _Teamqueries.GetById(id),
				PlayersOnTeam = _Playerqueries.GetAllFromTeam(id),
				AvailablePlayers = _Playerqueries.GetAllAvailablePlayers()
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult UpdateTeam(TeamOption team)
		{
			var request = new TeamRequest
			{
				
				TeamName = team.TeamName,
				DivisionId = team.DivisionId,
				
			};

			var result = _service.UpdateTeam(team.Id , request);

			if (!result)
			{
				TempData["Error"] = "Failed to update team.";
				return RedirectToAction("Edit", new { id = team.Id });
			}

			TempData["Success"] = "Team updated successfully.";
			return RedirectToAction("Edit", new { id = team.Id });
		}

		[HttpPost]
		public IActionResult AddPlayer(int teamId, int playerId)
		{
			var result = _service.AssignPlayerToTeam(playerId , teamId);
			if (!result)
			{
				TempData["Error"] = "Failed to add player to team.";
				return RedirectToAction("Edit", new { id = teamId });
			}
			TempData["Success"] = "Player added.";
			return RedirectToAction("Edit", new { id = teamId });
		}


		[HttpPost]
		public IActionResult RemovePlayer(int playerId, int teamId)
		{
			_service.RemovePlayerFromTeam(playerId);
			TempData["Success"] = "Player removed.";
			return RedirectToAction("Edit", new { id = teamId });
		}

        [HttpPost]
        public IActionResult MarkAsPaid(int id)
        {
            var result = _service.MarkAsPaid(id);

            if (!result)
            {
                TempData["Error"] = "Failed to mark team as paid";
            }
            else
            {
                TempData["SuccessMessage"] = "Payment recorded successfully.";
            }

            return RedirectToAction("Index");
        }

    }
}
