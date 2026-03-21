using Bowling_Tournament_Registration_System.Ui.ReadModels;

namespace Bowling_Tournament_Registration_System.Ui.Queries
{
	public interface IPlayerReadModelGateway
	{
		 List<PlayerOption> GetAllFromTeam(int teamId);

		List<PlayerOption> GetAllAvailablePlayers();
		List<PlayerOption> GetAllPlayers();
	}
}
