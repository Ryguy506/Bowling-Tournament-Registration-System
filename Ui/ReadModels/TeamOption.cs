namespace Bowling_Tournament_Registration_System.Ui.ReadModels
{
    public class TeamOption
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        public int DivisionId { get; set; }

        public string DivisionName { get; set; }

        public bool RegistrationPaid { get; set; }

		public DateTime? PaymentDate { get; set; }

        public bool DivisionFull { get; set; }

        public bool IsEligible { get; set; }     

        public string ReasonNotEligible { get; set; }
    }
}
