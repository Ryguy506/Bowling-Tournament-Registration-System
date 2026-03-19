using Bowling_Tournament_Registration_System.Domain.Daos;
using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Domain.Dtos;
namespace Bowling_Tournament_Registration_System.Domain.Services
{
	public class TournamentManagementService : ITournamentManagementService
	{
		private readonly ITournamentDao _tournamentDao;
		public TournamentManagementService(ITournamentDao tournamentDao)
		{
			_tournamentDao = tournamentDao;
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
