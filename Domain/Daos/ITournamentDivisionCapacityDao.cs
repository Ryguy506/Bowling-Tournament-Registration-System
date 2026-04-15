using Bowling_Tournament_Registration_System.Domain.Entities;

namespace Bowling_Tournament_Registration_System.Domain.Daos
{
	public interface ITournamentDivisionCapacityDao
	{
        int GetDivisionCapacity(int tournamentId, int divisionId);

        TournamentDivisionCapacity GetByTournamentAndDivision(int tournamentId, int divisionId); 

        void Add(TournamentDivisionCapacity capacity);

        void Update(TournamentDivisionCapacity capacity);
    }
}
