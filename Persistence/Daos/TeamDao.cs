using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Domain.Daos;
using Bowling_Tournament_Registration_System.Persistence.Ef;

namespace Bowling_Tournament_Registration_System.Persistence.Daos
{
	public class TeamDao : ITeamDao
	{
		public readonly BowlingDbContext _db;

		public TeamDao(BowlingDbContext db)
		{
			_db = db;
		}

		public Team? GetById(int teamId)
		{
			return _db.Teams.Find(teamId);
		}

		public void Add(Team team)
		{
			_db.Teams.Add(team);
			_db.SaveChanges();
		}

		public void Update(Team team)
		{
			_db.Teams.Update(team);
			_db.SaveChanges();
		}

	}
}
