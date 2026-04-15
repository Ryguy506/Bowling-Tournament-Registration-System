
using Bowling_Tournament_Registration_System.Domain.Dtos;

namespace Bowling_Tournament_Registration_System.Domain.Services
{
	public interface ITournamentManagementService
	{
		TournamentResult CreateTournament(TournamentRequest tournament);
		TournamentResult UpdateTournament(int tournamentId , TournamentRequest tournament);


		 
	}
}
