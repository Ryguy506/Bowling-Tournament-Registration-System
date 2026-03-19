
using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Domain.Daos;
using Bowling_Tournament_Registration_System.Persistence.Ef;
namespace Bowling_Tournament_Registration_System.Persistence.Daos
{
	public class TournamentRegistrationDao : ITournamentRegistrationDao
	{
		public readonly BowlingDbContext _db;

		public TournamentRegistrationDao(BowlingDbContext db)
		{
			_db = db;
		}


		public bool Exists(int tournamentId, int teamId)
		{
			return _db.TournamentRegistrations.Any(tr => tr.TournamentId == tournamentId && tr.TeamId == teamId);
		}

		public int GetCountByTournament(int tournamentId)
		{
			return _db.TournamentRegistrations.Count(tr => tr.TournamentId == tournamentId);
		}

		public void Add(TournamentRegistration registration)
		{
			_db.TournamentRegistrations.Add(registration);
			_db.SaveChanges();
		}
	}
}
