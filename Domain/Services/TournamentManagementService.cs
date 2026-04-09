using Bowling_Tournament_Registration_System.Domain.Daos;
using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Domain.Dtos;
namespace Bowling_Tournament_Registration_System.Domain.Services
{
	public class TournamentManagementService : ITournamentManagementService
	{
		private readonly ITournamentDao _tournamentDao;
		private readonly ITournamentDivisionCapacityDao _divisionCapacityDao;
		public TournamentManagementService(ITournamentDao tournamentDao , ITournamentDivisionCapacityDao divisionCapacityDao)
		{
			_tournamentDao = tournamentDao;
			_divisionCapacityDao = divisionCapacityDao;
		}


		public int CreateTournament(TournamentRequest tournament)
		{

			var newTournament = new Tournament
			{
				Name = tournament.Name,
				TournamentDate = tournament.TournamentDate,
				Location = tournament.Location,
				Capacity = tournament.Capacity,
				RegistrationOpen = true
			};

			_tournamentDao.Add(newTournament);


			foreach (var division in tournament.DivisionCapacities)
			{
				var divisionCapacity = new TournamentDivisionCapacity
				{
					TournamentId = newTournament.TournamentId,
					DivisionId = division.DivisionId,
					Capacity = division.Capacity
				};
				_divisionCapacityDao.Add(divisionCapacity);
			}

			return newTournament.TournamentId;
		}



		public bool UpdateTournament(int tournamentId, TournamentRequest tournament)
		{
			var existingTournament = _tournamentDao.GetById(tournamentId);
			if (existingTournament == null) return false; 
			
			existingTournament.Name = tournament.Name;
			existingTournament.TournamentDate = tournament.TournamentDate;
			existingTournament.Location = tournament.Location;
			existingTournament.Capacity = tournament.Capacity;
			_tournamentDao.Update(existingTournament);
			return true;
		}
	}
}
