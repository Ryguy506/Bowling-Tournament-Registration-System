using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Domain.Daos;
using Bowling_Tournament_Registration_System.Persistence.Ef;
namespace Bowling_Tournament_Registration_System.Persistence.Daos
{
	public class PlayerDao : IPlayerDao
	{

		private readonly BowlingDbContext _db;
		public PlayerDao(BowlingDbContext db)
		{
			_db = db;
		}
		public Player? GetById(int playerId)
		{
			return _db.Players.Find(playerId);
		}
		public List<Player> GetByTeamId(int teamId)
		{
			return _db.Players.Where(p => p.TeamId == teamId).ToList();
		}

		public List<Player> GetAvailable()
		{
			return _db.Players.Where(p => p.TeamId == null).ToList();
		}

		public void Update(Player player)
		{
			_db.Players.Update(player);
			_db.SaveChanges();
		}
	}
}
