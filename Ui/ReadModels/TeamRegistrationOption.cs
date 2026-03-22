namespace Bowling_Tournament_Registration_System.Ui.ReadModels
{
    public class TeamRegistrationOption
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public bool IsEligible { get; set; }
        public string ReasonNotEligible { get; set; }
    }
}
