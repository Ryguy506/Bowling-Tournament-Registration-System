using Bowling_Tournament_Registration_System.Ui.Queries;
using Bowling_Tournament_Registration_System.Persistence.Ef;
using Bowling_Tournament_Registration_System.Ui.ReadModels;
namespace Bowling_Tournament_Registration_System.Persistence.Queries
{
	
	public class PlayerReadModelGateway : IPlayerReadModelGateway
	{

		private readonly BowlingDbContext _context;

		public PlayerReadModelGateway(BowlingDbContext context)
		{
			_context = context;
		}


		public List<PlayerOption> GetAllPlayers()
		{
			return _context.Players.Select(p => new PlayerOption
			{
				Id = p.PlayerId,
				Name = p.PlayerName,
				Email = p.Email,
				City = p.City,
				Province = p.Province
			}).ToList();
		}


		public List<PlayerOption> GetAllFromTeam(int teamid)
		{
			return _context.Players.Where(p => p.TeamId == teamid)
				.Select(p => new PlayerOption
				{
					Id = p.PlayerId,
					Name = p.PlayerName,
					Email = p.Email,
					City = p.City,
					Province = p.Province
				}).ToList();

		}


		public List<PlayerOption> GetAllAvailablePlayers()
		{
			return _context.Players.Where(p => p.TeamId == null)
				.Select(p => new PlayerOption
				{
					Id = p.PlayerId,
					Name = p.PlayerName,
					Email = p.Email,
					City = p.City,
					Province = p.Province
				}).ToList();

		}
	}
}
