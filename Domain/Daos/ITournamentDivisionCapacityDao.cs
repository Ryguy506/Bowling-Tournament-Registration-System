namespace Bowling_Tournament_Registration_System.Domain.Daos
{
    public interface ITournamentDivisionCapacityDao
    {
        int GetCapacity(int tournamentId, int divisionId);
    }
}
