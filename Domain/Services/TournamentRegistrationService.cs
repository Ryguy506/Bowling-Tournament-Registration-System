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


		public TournamentRegistrationService(ITeamDao teamDao, ITournamentDao tournamentDao , ITournamentRegistrationDao registrationDao, IPlayerDao playerDao ,  ITournamentDivisionCapacityDao capacityDao)
        {
            _teamDao = teamDao;
            _tournamentDao = tournamentDao;
            _tournamentRegistrationDao = registrationDao;
            _playerDao = playerDao;
			_divisionCapacityDao = capacityDao;

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
                .GetDivisionCapacity(tournamentId, team.DivisionId);

            bool tournamentFull = totalRegistered >= tournament.Capacity;
            bool divisionFull = divisionRegistered >= divisionCapacity;

            var existing = _tournamentRegistrationDao
                .GetById(tournamentId, teamId);

            if (existing != null && existing.Status == RegistrationStatus.Cancelled)
            {
                if (tournamentFull || divisionFull)
                {
                    existing.Status = RegistrationStatus.Waitlisted;
                    existing.WaitlistPosition =
                        _tournamentRegistrationDao.GetWaitlistCount(tournamentId) + 1;
                }
                else
                {
                    existing.Status = RegistrationStatus.Confirmed;
                    existing.WaitlistPosition = null;
                }

                existing.RegisteredOn = DateTime.UtcNow;

                _tournamentRegistrationDao.SaveChanges();

                PromoteWaitlist(tournamentId);

                return existing.Status == RegistrationStatus.Confirmed
                    ? RegistrationResult.Ok()
                    : RegistrationResult.Waitlisted();
            }

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
            PromoteWaitlist(tournamentId);
            return RegistrationResult.Ok();

		}


		public bool CancelRegistration(int tournamentId, int teamId )
		{
			var registration = _tournamentRegistrationDao.GetById(tournamentId, teamId);
			if (registration == null || registration.Status == RegistrationStatus.Cancelled)
				return false;

            var team = _teamDao.GetById(teamId);

            registration.Status = RegistrationStatus.Cancelled;
			_tournamentRegistrationDao.SaveChanges();

            int divisionCapacity = _divisionCapacityDao
				.GetDivisionCapacity(tournamentId, team.DivisionId);

            PromoteWaitlist(registration.TournamentId);
            _tournamentRegistrationDao.SaveChanges();
            return true;
		}

		public void PromoteWaitlist(int tournamentId)
		{
            var waitlist = _tournamentRegistrationDao
                .GetAllWaitlist(tournamentId)
                .Where(w => w.Status == RegistrationStatus.Waitlisted)
                .OrderBy(w => w.WaitlistPosition)
                .ToList();
            if (waitlist.Count == 0)
				return;

            TournamentRegistration promoted = null;

            foreach (var entry in waitlist)
            {
                var team = _teamDao.GetById(entry.TeamId);

                int divisionRegistered = _tournamentRegistrationDao
                    .GetCountByTournamentAndDivision(tournamentId, team.DivisionId);

                int divisionCapacity = _divisionCapacityDao
                    .GetDivisionCapacity(tournamentId, team.DivisionId);

                if (divisionRegistered < divisionCapacity)
                {
                    promoted = entry;
                    break;
                }
            }

            if (promoted == null)
                return;

            promoted.Status = RegistrationStatus.Confirmed;
            promoted.WaitlistPosition = null;

            var remaining = waitlist.Where(w => w != promoted).ToList();

            int position = 1;
            foreach (var w in remaining)
            {
                w.WaitlistPosition = position++;
            }

            _tournamentRegistrationDao.SaveChanges();
        }


	}
	
}
