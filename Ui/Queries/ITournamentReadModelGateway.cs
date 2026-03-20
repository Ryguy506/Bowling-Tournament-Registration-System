using Bowling_Tournament_Registration_System.Ui.ReadModels;

namespace Bowling_Tournament_Registration_System.Ui.Queries
{
    public interface ITournamentReadModelGateway
    {
        List<TournamentOption> GetAll();

        TournamentDetailsOption GetById(int id);
    }
}
