using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Domain.Dtos;

namespace Bowling_Tournament_Registration_System.Domain.Daos
{
	public interface ITournamentRegistrationDao
	{
		bool Exists(int tournamentId, int teamId);  
		int GetCountByTournament(int tournamentId); 
		void Add(TournamentRegistration registration);
	}
}
