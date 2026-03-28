
namespace Bowling_Tournament_Registration_System.Domain.Entities
{
	public class TournamentRegistration
	{
		public int RegistrationId { get; set; }
		public int TournamentId { get; set; }
		public int TeamId { get; set; }
		public DateTime RegisteredOn { get; set; }
		public RegistrationStatus Status { get; set; }

		public int? WaitlistPosition { get; set; }
		public Team Team { get; set; }
    }
}
