namespace Bowling_Tournament_Registration_System.Ui.ReadModels
{
    public class TournamentOption
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int RegisteredCount { get; set; }

        public int Capacity { get; set; }
    }
}
