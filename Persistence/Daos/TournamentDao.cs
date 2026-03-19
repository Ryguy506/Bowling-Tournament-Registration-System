using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Domain.Daos;
using Bowling_Tournament_Registration_System.Persistence.Ef;
namespace Bowling_Tournament_Registration_System.Persistence.Daos
{
	public class TournamentDao : ITournamentDao
	{

		public readonly BowlingDbContext _db;

		public TournamentDao(BowlingDbContext db)
		{
			_db = db;
		}

		public Tournament? GetById(int tournamentId)
		{
			return _db.Tournaments.Find(tournamentId);
		}

		public void Add(Tournament tournament)
		{
			_db.Tournaments.Add(tournament);
			_db.SaveChanges();
		}

		public void Update(Tournament tournament)
		{
			_db.Tournaments.Update(tournament);
			_db.SaveChanges();

		}
	}
}
