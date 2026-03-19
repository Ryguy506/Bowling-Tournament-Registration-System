namespace Bowling_Tournament_Registration_System.Ui.Queries
{
    public interface ITournamentReadModelGateway
    {
        List<TournamentListReadModel> GetAll();

        TournamentDetailsReadModel GetById(int id);
    }
}
