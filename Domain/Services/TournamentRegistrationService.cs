using Bowling_Tournament_Registration_System.Domain.Daos;
using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Domain.Dtos;
namespace Bowling_Tournament_Registration_System.Domain.Services
{
	public class TournamentRegistrationService : ITournamentRegistrationService
	{
		private readonly ITeamDao _teamDao;
		private readonly ITournamentDao _tournamentDao;
		private readonly ITournamentRegistrationDao _tournamentRegistrationDao;
		private readonly IPlayerDao _playerDao;
		public TournamentRegistrationService(ITeamDao teamDao, ITournamentDao tournamentDao , ITournamentRegistrationDao registrationDao , IPlayerDao playerDao)
		{
			_teamDao = teamDao;
			_tournamentDao = tournamentDao;
			_tournamentRegistrationDao = registrationDao;
			_playerDao = playerDao;

		}
		
		public RegistrationResult RegisterTeam(int tournamentId, int teamId)
		{
			var tournament = _tournamentDao.GetById(tournamentId);
			var team = _teamDao.GetById(teamId);

			if (_playerDao.GetCountByTeamId(teamId) != 4)
				return RegistrationResult.Fail("Team must have exactly 4 players to register.");
			
			if (!team.RegistrationPaid)
				return RegistrationResult.Fail("Team must pay registration fee first");
			
			if (_tournamentRegistrationDao.Exists(tournamentId, teamId))
				return RegistrationResult.Fail("Team is already registered for this tournament.");

			if (_tournamentRegistrationDao.GetCountByTournament(tournamentId) >= tournament.Capacity)
				return RegistrationResult.Fail("Tournament is at full capacity.");
			
			var registration = new TournamentRegistration
				{
				TournamentId = tournamentId,
				TeamId = teamId,
				RegisteredOn = DateTime.UtcNow,
				Status = RegistrationStatus.Confirmed,
			};

			_tournamentRegistrationDao.Add(registration);
			return RegistrationResult.Ok();



		}
	}
}
