namespace Bowling_Tournament_Registration_System.Domain.Dtos
{

		public class TournamentResult
		{
			public bool Success { get; set; }
			public string? ErrorMessage { get; set; }

			public static TournamentResult Ok()
			{
				return new TournamentResult
				{
					Success = true
					
				};
			}

			public static TournamentResult Fail(string error)
			{
				return new TournamentResult
				{
					Success = false,
					ErrorMessage = error
				};
			}
		}
	
}
