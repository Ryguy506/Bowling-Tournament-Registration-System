using Bowling_Tournament_Registration_System.Domain.Entities;

namespace Bowling_Tournament_Registration_System.Domain.Daos
{
	public interface ITournamentDao
	{
		Tournament? GetById(int tournamentId);

		void Add(Tournament tournament);

		void Update(Tournament tournament);
	}
}
