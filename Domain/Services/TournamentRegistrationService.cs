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
        private readonly ITournamentDivisionCapacityDao _divisionCapacityDao;

        public TournamentRegistrationService(ITeamDao teamDao, ITournamentDao tournamentDao , ITournamentRegistrationDao registrationDao, IPlayerDao playerDao, ITournamentDivisionCapacityDao divisionCapacityDao)
        {
            _teamDao = teamDao;
            _tournamentDao = tournamentDao;
            _tournamentRegistrationDao = registrationDao;
            _playerDao = playerDao;
            _divisionCapacityDao = divisionCapacityDao;
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

            int totalRegistered = _tournamentRegistrationDao.GetCountByTournament(tournamentId);

            int divisionRegistered = _tournamentRegistrationDao
                .GetCountByTournamentAndDivision(tournamentId, team.DivisionId);

            int divisionCapacity = _divisionCapacityDao
                .GetCapacity(tournamentId, team.DivisionId);

            bool tournamentFull = totalRegistered >= tournament.Capacity;
            bool divisionFull = divisionRegistered >= divisionCapacity;

            var registration = new TournamentRegistration
            {
                TournamentId = tournamentId,
                TeamId = teamId,
                RegisteredOn = DateTime.UtcNow
            };
            
            if (tournamentFull || divisionFull)
            {
                registration.Status = RegistrationStatus.Waitlisted;
                registration.WaitlistPosition =
                    _tournamentRegistrationDao.GetWaitlistCount(tournamentId) + 1;

                _tournamentRegistrationDao.Add(registration);

                return RegistrationResult.Waitlisted();
            }

            registration.Status = RegistrationStatus.Confirmed;
            _tournamentRegistrationDao.Add(registration);

            return RegistrationResult.Ok();
        }
	}
}
