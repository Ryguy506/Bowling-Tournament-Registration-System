using Bowling_Tournament_Registration_System.Domain.Entities;

namespace Bowling_Tournament_Registration_System.Domain.Daos
{
	public interface ITournamentRegistrationDao
	{
		bool Exists(int tournamentId, int teamId);  
		int GetCountByTournament(int tournamentId); 
		void Add(TournamentRegistration registration);
	}
}
