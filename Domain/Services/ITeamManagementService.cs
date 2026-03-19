using Bowling_Tournament_Registration_System.Domain.Dtos;
namespace Bowling_Tournament_Registration_System.Domain.Services
{
	public interface ITeamManagementService
	{
		int CreateTeam(TeamRequest team);
		bool UpdateTeam(int teamId, TeamRequest team);

		bool MarkAsPaid(int teamId);

		bool AssignPlayerToTeam(int playerId, int teamId);

		bool RemovePlayerFromTeam(int playerId);
	}
}
