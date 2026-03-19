
using Bowling_Tournament_Registration_System.Domain.Dtos;

namespace Bowling_Tournament_Registration_System.Domain.Services
{
	public interface ITournamentManagementService
	{
		int CreateTournament(TournamentRequest tournament);
		bool UpdateTournament(int tournamentId , TournamentRequest tournament);


		 
	}
}
