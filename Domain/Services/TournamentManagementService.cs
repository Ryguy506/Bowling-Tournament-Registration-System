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


		public TournamentResult CreateTournament(TournamentRequest tournament)
		{

			int totalDivisionCapacity = tournament.DivisionCapacities.Sum(d => d.Capacity);
			if (totalDivisionCapacity != tournament.Capacity)
				return TournamentResult.Fail("Total division capacities must equal tournament capacity");

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

			return TournamentResult.Ok();
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

            foreach (var dc in tournament.DivisionCapacities)
            {
                var existing = _divisionCapacityDao
                    .GetByTournamentAndDivision(tournamentId, dc.DivisionId);

                if (existing != null)
                {
                    existing.Capacity = dc.Capacity;
                    _divisionCapacityDao.Update(existing);
                }
                else
                {
                    _divisionCapacityDao.Add(new TournamentDivisionCapacity
                    {
                        TournamentId = tournamentId,
                        DivisionId = dc.DivisionId,
                        Capacity = dc.Capacity
                    });
                }
            }

            return true;
        }
	}
}
