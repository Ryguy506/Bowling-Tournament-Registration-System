namespace Bowling_Tournament_Registration_System.Domain.Dtos
{
	public class TournamentRequest
	{
		public string Name { get; set; }
		public DateTime TournamentDate { get; set; }
		public string Location { get; set; }
		public int Capacity { get; set; }
	}
}
