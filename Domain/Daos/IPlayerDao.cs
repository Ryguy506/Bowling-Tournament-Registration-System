using Bowling_Tournament_Registration_System.Domain.Entities;
namespace Bowling_Tournament_Registration_System.Domain.Daos
{
	public interface IPlayerDao
	{
		Player? GetById(int playerId);
		List<Player> GetByTeamId(int teamId);
		List<Player> GetAvailable(); 
		void Update(Player player);
	
	}
}
