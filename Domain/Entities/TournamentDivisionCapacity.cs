namespace Bowling_Tournament_Registration_System.Domain.Entities
{
	public class TournamentDivisionCapacity
	{
		public int Id { get; set; }
		public int TournamentId { get; set; }
		public int DivisionId { get; set; }      
		public int Capacity { get; set; }

		
	}
}
