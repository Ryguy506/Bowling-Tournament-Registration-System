namespace Bowling_Tournament_Registration_System.Domain.Entities
{
	public class Team
	{
		public int TeamId { get; set; }  

		public int TeamName { get; set; }
		
		public int DivisionId { get; set; }
		public bool RegistrationPaid { get; set; } = false;

		public DateTime? PaymentDate { get; set; }


	}
}
