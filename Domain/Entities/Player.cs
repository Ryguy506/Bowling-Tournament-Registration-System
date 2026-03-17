namespace Bowling_Tournament_Registration_System.Domain.Entities
{
	public class Player
	{
		public int PlayerId { get; set; }
		public string PlayerName { get; set; }
		public string Email { get; set; } 

		public string City { get; set; }

		public string Province { get; set; }

		public int? TeamId { get; set; }
	}
}
