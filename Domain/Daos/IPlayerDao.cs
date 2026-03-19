using Bowling_Tournament_Registration_System.Domain.Entities;
namespace Bowling_Tournament_Registration_System.Domain.Daos
{
	public interface IPlayerDao
	{
		Player? GetById(int playerId);
		int GetCountByTeamId(int teamId);
		void Update(Player player);
	
	}
}
