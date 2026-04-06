using Bowling_Tournament_Registration_System.Domain.Entities;

namespace Bowling_Tournament_Registration_System.Domain.Daos
{
	public interface ITournamentRegistrationDao
	{
		bool Exists(int tournamentId, int teamId);  
		int GetCountByTournament(int tournamentId); 
		void Add(TournamentRegistration registration);

		int GetWaitlistCount(int tournamentId);

		TournamentRegistration GetById(int tournamentId, int teamId);

		List<TournamentRegistration> GetAllWaitlist(int tournamentId);


		void SaveChanges();

	}
}
