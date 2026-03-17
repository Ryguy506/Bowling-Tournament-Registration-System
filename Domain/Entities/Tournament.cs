namespace Bowling_Tournament_Registration_System.Domain.Entities
{
	public class Tournament
	{
		public int TournamentId { get; set; }
		public string Name { get; set; } 
		public DateTime TournamentDate { get; set; }

		public string Location { get; set; }
		public int Capacity { get; set; }
		public bool RegistrationOpen { get; set; }
	}
}
