using Bowling_Tournament_Registration_System.Domain.Dtos;
namespace Bowling_Tournament_Registration_System.Domain.Services
{
	public interface ITournamentRegistrationService
	{
		RegistrationResult RegisterTeam(int tournamentId, int teamId);
	}
}
